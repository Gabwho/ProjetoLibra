using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControladorDeCenas : MonoBehaviour {
	
	private ControladorPortas porta;
	private GameObject player1, player2;
	private bool floresta1Completa;
	private Image fade;
	private GameObject fadeImage;
	
	void Start () {
		StopAllCoroutines ();
		player1 = GameObject.Find ("Raphael");
		player2 = GameObject.Find ("Jade");
		fadeImage = GameObject.Find ("Fade");
		fade = fadeImage.GetComponent<Image> ();
	}
	
	public void LoadScene(int ID) {
		if (ID == 1){
			Application.LoadLevel("Menu");
			ID = 0;
		}

		if (ID == 2){
			Application.LoadLevel ("Praia1");
			ID = 0;
		}

		if (ID == 3){
			if(!floresta1Completa){
				Application.LoadLevel("Floresta");
			}else{
				Application.LoadLevel("Vila");
				PosicaoPlayer(0, 0, 0);
			}
			ID = 0;
		}

		if (ID == 4){
			Application.LoadLevel ("Floresta2");
			ID = 0;
		}

		if (ID == 5){
			Application.LoadLevel ("Floresta3");
			ID = 0;
		}

		if (ID == 6){
			Application.LoadLevel ("Vila");

			if(!floresta1Completa)
				floresta1Completa = true;

			ID = 0;
			if(Application.loadedLevelName == "CasaElvira"){
				PosicaoPlayer(0, 0, 32.6f);
			}
		}

		if (ID == 7){
			Application.LoadLevel ("CasaElvira");
			ID = 0;
		}
	}

	public void FadeAndReload(Color c){
		c.a = 0;
		StartCoroutine(Fade(c));
	}

	public void ControladordoDiario(){
	}

	void PosicaoPlayer (float x, float y, float z){
		PlayerPosition.position.x = x;
		PlayerPosition.position.y = y;
		PlayerPosition.position.z = z;
		
	}

	IEnumerator Fade(Color c){
		while (c.a < 1f) {
			c.a += 0.05f;
			fade.color = c;
			yield return new WaitForSeconds(0.025f);
			if(c.a >= 1f)
				Application.LoadLevel (Application.loadedLevel);
		}
	}
	
}
