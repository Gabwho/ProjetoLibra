using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class ControladorDeFalas : MonoBehaviour {

	public TextAsset docCaramello, docElvira, docKidd, docRafael;
	public string[] falasCaramello, falasElvira, falasKidd, falasRafael;
	private GameObject player;
	private Movement playerControl;

	void Start () {
		player = GameObject.Find("Raphael");
		playerControl = player.GetComponent<Movement> ();

		if (GameObject.Find ("Caramello")) {
			falasCaramello = docCaramello.text.Split ("\n" [0]);
			Debug.Log (falasCaramello[1].Substring(3, falasCaramello[1].Length - 7));
		}

		if (GameObject.Find ("Elvira")) {
			falasElvira = docElvira.text.Split("\n"[0]);
			Debug.Log (falasElvira[2].Substring(3, (falasElvira[2].Length - 7)));
		}

		if (GameObject.Find ("Kidd")) {
			falasKidd = docKidd.text.Split("\n"[0]);
			Debug.Log (falasKidd[1].Substring(3, falasKidd[1].Length - 7));
		}

		if (GameObject.Find ("Raphael")) {
			falasRafael = docRafael.text.Split ("\n" [0]);
			Debug.Log (falasRafael[1].Substring (3));
		}
	}

	public void setPodeAndar(bool pode){
		playerControl.setPodeAndar (pode);
	}
}
