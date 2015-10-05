using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	
	public CharacterController player1, player2;
	public float speed;

	public Animator controllerP1, controllerP2;

	private ControladorPortas porta;
	private ControladorDeCenas cena;
	private int doorID;

	public bool player1Active = true;
	public bool player2Active = false;
	private bool mudou = false;

	public bool isAbletoWalk = true;

	public Vector3 movement = Vector3.zero;
	private Quaternion rot;

	//Classe do Joystick
	private VirtualJoystick joystick;

	void Start(){
		joystick = GetComponent <VirtualJoystick>();
		porta = new ControladorPortas ();
		cena = new ControladorDeCenas ();
	}

	public void setPodeAndar(bool open){
		isAbletoWalk = open;
	}

	public bool getPodeAndar(){
		return isAbletoWalk;
	}
	
	void FixedUpdate(){
		if (isAbletoWalk) {
			if (Input.GetKeyDown ("1")) {
				player1Active = true;
				player2Active = false;
			}
		
			if (Input.GetKeyDown ("2")) {
				player2Active = true;
				player1Active = false;
			}

			if (Input.touchCount == 0) {
				float moveHorizontal = Input.GetAxisRaw ("Horizontal");
				float moveVertical = Input.GetAxisRaw ("Vertical");
				Move (moveHorizontal, moveVertical);
			}
			if (Input.touchCount >= 1) {
				float moveHorizontal = joystick.movement.x;
				float moveVertical = joystick.movement.y;
				Move (moveHorizontal, -moveVertical);
			}
		}
		if (!isAbletoWalk) {
			controllerP1.SetBool("taAndando", false);
			controllerP2.SetBool("taAndando", false);
		}
	}

	void Move (float h, float v){
		movement.Set (h, 0f, v);

		rot = Quaternion.LookRotation(movement);

		movement *= speed;

		if (player1Active && isAbletoWalk){
			player1.Move (movement * Time.deltaTime);
			if(h != 0 || v != 0){
				player1.transform.rotation = rot;
				controllerP1.SetBool("taAndando", true);
			}else{
				controllerP1.SetBool("taAndando", false);
			}
		}

		if (player2Active && isAbletoWalk) {
			player2.Move (movement * Time.deltaTime);
			if(h != 0 || v != 0){
				player2.transform.rotation = rot;
				controllerP2.SetBool("taAndando", true);
			}else{
				controllerP2.SetBool("taAndando", false);
			}
		}
	}
	
	public void TrocaPersonagem(){
		mudou = false;
		if (player1Active == true && mudou == false && isAbletoWalk) {
			player2Active = true;
			player1Active = false;
			mudou = true;
		}
		
		if (player2Active == true && mudou == false && isAbletoWalk) {
			player1Active = true;
			player2Active = false;
		}
	}
}