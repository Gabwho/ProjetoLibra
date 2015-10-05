using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VolumeControl : MonoBehaviour {

	public Slider slideVolume;

	// Use this for initialization
	public void Volume (){
		float valorSlide = slideVolume.value;
		Debug.Log (valorSlide);
		AudioListener.volume = (valorSlide / 100);
	}
}
