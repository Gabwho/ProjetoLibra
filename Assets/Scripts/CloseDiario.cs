using UnityEngine;
using System.Collections;

public class CloseDiario : MonoBehaviour {

	public GameObject diario;
	Movement movement;
	private GameObject player;

	void Start(){
		player = GameObject.Find ("Raphael");
		movement = player.GetComponent<Movement>();
	}

	public void FechaDiario(){
		movement.setPodeAndar(true);
		Destroy (diario);
	}
}
