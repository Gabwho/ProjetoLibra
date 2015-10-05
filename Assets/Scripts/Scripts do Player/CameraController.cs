using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	private Movement player;
	private GameObject cam1, cam2;
	private GameObject jogadorComScript;
	private Vector3 camPosition1, camPosition2;
	
	void Start ()
	{	
		player = new Movement ();
		jogadorComScript = GameObject.Find ("Raphael");
		player = jogadorComScript.GetComponent<Movement> ();
		cam1 = GameObject.Find ("CamPositionP1");
		cam2 = GameObject.Find ("CamPositionP2");
		transform.rotation = cam1.transform.rotation;
	}
	
	void LateUpdate ()
	{
		if (player.player1Active == true) {
			camPosition1 = cam1.transform.position;
			transform.position = camPosition1;
		}
		if (player.player2Active == true) {
			camPosition2 = cam2.transform.position;
			transform.position = camPosition2;
		}
	}
}