using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public float speed;
	
	//Classe do Joystick
	private VirtualJoystick joystick;

	void Start(){
		
		//Instância do joystick
		joystick = GetComponent <VirtualJoystick>();
	}

	void FixedUpdate(){ //Para rodar antes de calculos de fisica
		
		//Troquei o Input.GetAxis() pelo joystick.movement
		float moveHorizontal = joystick.movement.x;
		float moveVertical = joystick.movement.y;
		
		//O moveVertical está negativo por gambiarra (o analógico estava invertido na vertical)
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, -moveVertical);
	
		//Pequena gambiarra: coloquei um identificador de touch porque a bola estava continuando a andar
		//mesmo depois de eu já ter parado de tocar.
		if(Input.touchCount == 1)
			GetComponent<Rigidbody>().AddForce (movement * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Saida 1") {
			Application.LoadLevel ("Fase 2");
			DontDestroyOnLoad (GetComponent<Rigidbody>());
		}
		if (other.gameObject.tag == "Saida 2") {
			Application.LoadLevel ("Fase 1");
			DontDestroyOnLoad (GetComponent<Rigidbody>());
		}
		
	}


}
