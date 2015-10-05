using UnityEngine;
using System.Collections;

public class Roam : MonoBehaviour {
	public Vector3 newPos;    
	public int maxX, maxZ;
	public int minX, minZ;
	public float speed;
	bool ready;
	int waitTime;
	
	void Start () {
		newChangeDirection();
		ready = true;
		waitTime = Random.Range (1, 3);
	}
	
	void Update () {
		if (transform.position != newPos) {
			transform.LookAt(newPos);
		}
		transform.position = Vector3.MoveTowards (transform.position, newPos, speed * Time.deltaTime);
		if ((transform.position == newPos) && ready)
		{
			StartCoroutine(wait());
		}
	}
	
	void newChangeDirection()
	{
		int posX = Random.Range (minX, maxX);
		int posZ = Random.Range (minZ, maxZ);
		newPos = new Vector3 (posX, 0, posZ);
	}
	
	IEnumerator wait()
	{
		ready = false;
		yield return new WaitForSeconds (waitTime);
		newChangeDirection();
		ready = true;
	}
}
