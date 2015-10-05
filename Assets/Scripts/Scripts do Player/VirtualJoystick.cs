/*
Esse script não precisa ser adicionado a nenhum GameObject. A única coisa que você precisará fazer é
instanciar ele na classe de movimento do personagem. Pra tirar as dúvidas de como mencionar ele na outra
classe, acrescentei o script de movimento do personagem do Roll a Ball modificado na pasta também.
Have fun!

Murilo
*/

using UnityEngine;
using System.Collections;

public class VirtualJoystick : MonoBehaviour
{
	public Texture2D padBackground;
	public Texture2D padController;
	private bool isMovingFinger = false;
	private Movement checaDiario;
	private GameObject player;

	// add some new variables:
	private Vector2 padControllerPosition = Vector2.zero;
	private Vector2 padBackgroundPosition = Vector2.zero;
	private float joystickSize = 100.0f;

	public const float padRadius = 80.0f;

	// add a new public variable which will be used by other scripts
	// to know the direction of the joystick. (0,0) means the joystick
	// is idle, (1,0) is pointing to the left, (0, -1) is pointing
	// down, and so on.
	public Vector2 movement = Vector2.zero;

	Vector2 touchPosition;

	void Start(){
		player = GameObject.Find ("Raphael");
		checaDiario = player.GetComponent<Movement>();
	}

	public void Update(){

		if (Input.touchCount == 1) {
			Touch touch = Input.touches [0];
			// get the finger position and transform
			// the coordinate system to top-to-bottom:
			touchPosition = new Vector2 (
				touch.position.x,
				Screen.height - touch.position.y
			);
			
			switch (touch.phase) {
			case TouchPhase.Began:
				this.isMovingFinger = true;
				this.padControllerPosition = touchPosition;
				this.padBackgroundPosition = touchPosition;
				//Debug.Log (touchPosition);
				break;
			case TouchPhase.Moved:
				this.padControllerPosition = touchPosition;
				break;
			case TouchPhase.Stationary:
				break;
			case TouchPhase.Canceled:
				break;
			case TouchPhase.Ended:
				this.isMovingFinger = false;
				movement = Vector2.zero;
				break;
			}

			// get the direction of the pad:
			Vector2 direction = this.padControllerPosition;
			direction -= this.padBackgroundPosition;
			
			// normalize it and store the value in the movement
			// variable:
			this.movement = direction.normalized;

		}
	}
	
	public void OnGUI(){
		if (checaDiario.isAbletoWalk == true) {
			if (this.isMovingFinger) {
				Rect backgroundRect = new Rect (
				this.padBackgroundPosition.x - (this.joystickSize / 2.0f),
				this.padBackgroundPosition.y - (this.joystickSize / 2.0f),
				this.joystickSize,
				this.joystickSize
				);
			
				Rect controllerRect = new Rect (
				this.padControllerPosition.x - (this.joystickSize / 2.0f),
				this.padControllerPosition.y - (this.joystickSize / 2.0f),
				this.joystickSize,
				this.joystickSize
				);
				GUI.DrawTexture (backgroundRect, this.padBackground);

				// get the distance between the two pads
				float padsDistance = Vector2.Distance (
				this.padBackgroundPosition,
				this.padControllerPosition
				);
			
				if (padsDistance > padRadius) {
					//Delimitar o espaço do analogico...
					padControllerPosition = padBackgroundPosition - Vector2.ClampMagnitude ((padBackgroundPosition - padControllerPosition), padRadius);
				}

				GUI.DrawTexture (controllerRect, this.padController);
			}
		}
	}
}