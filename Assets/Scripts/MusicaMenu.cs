using UnityEngine;
using System.Collections;

public class MusicaMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (Application.loadedLevelName == "Menu" || Application.loadedLevelName == "Bonus" || 
		    Application.loadedLevelName == "Config" || Application.loadedLevelName == "MenuNovoJogo") {
			DontDestroyOnLoad(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
