using UnityEngine;
using System.Collections;

public class ChecaPorta : MonoBehaviour {
	
	public CharacterController player;
	
	private ControladorPortas porta;
	private ControladorDeCenas cena;
	private int doorID;
	private GameObject controlador;

	void Start(){
		porta = new ControladorPortas ();
		controlador = GameObject.Find ("GENERALCONTROLLER");
		cena = controlador.GetComponent<ControladorDeCenas> ();
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Porta") {
			porta = other.gameObject.GetComponent<ControladorPortas>();
			doorID = porta.doorID;
			cena.LoadScene(doorID);
		}		
	}
	
	
	
	
}