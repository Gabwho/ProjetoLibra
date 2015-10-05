using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeInMenus : MonoBehaviour {

	Color c = Color.white;
	Color f = Color.white;
	private RawImage logoTU, logoFatec;
	private bool tuFoi, fatecFoi, running = false;

	// Use this for initialization
	void Start () {
		logoTU = GameObject.Find ("LogoTU").GetComponent<RawImage>();
		logoFatec = GameObject.Find ("LogoFatec").GetComponent<RawImage>();
		c.a = 1;
		f.a = 1;
		logoTU.color = f;
		logoFatec.color = f;
	}
	
	// Update is called once per frame
	void Update () {		
		if (Input.GetKeyDown (KeyCode.Return) && tuFoi && !running) {
			StartCoroutine (FadeMenu (c, logoFatec));
			fatecFoi = true;
		}

		if(Input.GetKeyDown(KeyCode.Return) && !tuFoi && !running){
			StartCoroutine (FadeMenu (c, logoTU));
			tuFoi = true;
		}
	}

	IEnumerator FadeMenu(Color c, RawImage logo){
		running = true;
		if (!tuFoi) {
			while (f.a > 0f) {
				f.a -= 0.05f;
				logoTU.color = f;
				yield return new WaitForSeconds (0.025f);
				if (f.a <= 0f) {
					running = false;
					StopAllCoroutines ();
				}
			}
		}
		if (tuFoi) {
			while (c.a > 0f) {
				c.a -= 0.05f;
				logoFatec.color = c;
				yield return new WaitForSeconds (0.025f);
				if (c.a <= 0f) {
					running = false;
					Application.LoadLevel("Menu");
				}
			}
		}
	}
}
