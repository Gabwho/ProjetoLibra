using UnityEngine;
using System.Collections;

public class CamSegueChar : MonoBehaviour {

	public CharacterController player;
	private Vector3 objPosition, offset;
	public float x, y, z;

	// Use this for initialization
	void Start () {
		offset.Set(x, y, z);
	}
	
	// Update is called once per frame
	void Update () {
		objPosition = player.transform.position + offset;
		transform.position = objPosition;
	}
}
