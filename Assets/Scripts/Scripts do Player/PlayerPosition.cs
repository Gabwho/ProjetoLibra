using UnityEngine;
using System.Collections;

public class PlayerPosition : MonoBehaviour {
	
	public static Vector3 position;

	// Use this for initialization
	void Start () {
		gameObject.transform.position = position;
	}

}
