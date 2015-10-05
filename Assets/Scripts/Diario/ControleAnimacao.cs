using UnityEngine;
using System.Collections;

public class ControleAnimacao : MonoBehaviour {
	
	Animator controllerP1, controllerP2;
	private ControladorDeCenas contrCena;
	Movement movP1;
	GameObject player1, player2, controller;

	// Use this for initialization
	void Start () {
		player1 = GameObject.Find ("Raphael");
		player2 = GameObject.Find ("Jade");
		controller = GameObject.Find ("GENERALCONTROLLER");
		contrCena = controller.GetComponent<ControladorDeCenas> ();
		controllerP1 = player1.GetComponent<Animator> ();
		controllerP2 = player2.GetComponent<Animator> ();
		movP1 = player1.GetComponent<Movement> ();

	}

	public void Frase1(bool apertou){
		if(movP1.player1Active == true)
		controllerP1.SetBool ("Frase1Apertada", apertou);

		if(movP1.player1Active == false)
		controllerP2.SetBool ("Frase1Apertada", apertou);
	}
	public void Sair(int fase){
		contrCena.LoadScene (fase);
	}
				
}
