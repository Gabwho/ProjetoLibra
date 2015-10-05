using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClickBotao : MonoBehaviour {
	
	public Image loadingImage;
	private float velFade = 1.5f;

	public void LoadingScene(string level){
		loadingImage.enabled = true;
		Application.LoadLevel (level);
	}

	public void NoLoadingScene(string level){
		Application.LoadLevel (level);
	}

	public void AdditiveScene(string level){
		Application.LoadLevelAdditive (level);
	}

	void FadeToBlack(){
		loadingImage.color = Color.Lerp(loadingImage.color, Color.black, velFade * Time.deltaTime);
	}
}