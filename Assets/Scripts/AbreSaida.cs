using UnityEngine;
using System.Collections;

public class AbreSaida : MonoBehaviour {

	public bool tocou = false;

	// Use this for initialization
	void OnTriggerEnter (Collider trig) {
		if (trig.gameObject.tag == "Box") {
			tocou = true;
		}
	}
	

}
