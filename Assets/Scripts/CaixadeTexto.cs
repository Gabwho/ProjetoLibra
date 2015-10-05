using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CaixadeTexto : MonoBehaviour {

	public Text texto, textoCaixa;
	private RawImage caixa;
	public bool taFalando = false, textoCompleto;
	public string str;
	private GameObject gameController;
	private ControladorDeFalas falas;

	private string textoT1 = "Esse é o texto em português que os NPCs irão falar! E já tem quebra de linha automática! HUEHUEHUEHUEHUEHUEHUEHUEHUEHUEHUE";
	private string textoT2 = "Olá! Este é o segundo texto de teste para esta caixa!";
	private string textoT3 = "MORDEKAISER ES NUMBER UNO";

	void Awake () {
		texto = GetComponent<Text> ();
		caixa = this.GetComponentInParent<RawImage>();
		textoCaixa = this.GetComponentInChildren<Text> ();
		gameController = GameObject.Find ("GENERALCONTROLLER");
		falas = gameController.GetComponent<ControladorDeFalas> ();
	}

	public void SetTaFalando(bool estaFalando){
		if (textoCompleto == true) {
			this.taFalando = estaFalando;
			gameController.GetComponent<ControladorDeFalas>().setPodeAndar(true);
		}
	}

	public void NPCDiz(string NPC, int fala){
		if (NPC == "Elvira") {
			taFalando = true;
			textoCompleto = false;
			caixa.enabled = true;
			textoCaixa.enabled = true;
			StartCoroutine (AnimateText (falas.falasElvira [fala].Substring (3, falas.falasElvira [fala].Length - 7))); 
		}
	}

	void Update(){ 
		if (taFalando == false) {
			caixa.enabled = false;
			textoCaixa.enabled = false;
		} else {
			caixa.enabled = true;
			textoCaixa.enabled = true;
		}

		if (Input.GetKey (KeyCode.Return)) {
			SetTaFalando(false);
		}

		if(Input.GetKeyDown("5")){
			if(taFalando == false){
				taFalando = true;
				textoCompleto = false;
				StartCoroutine( AnimateText(falas.falasElvira[1].Substring(3, falas.falasElvira[1].Length - 7))); 
			}
		}
		if(Input.GetKeyDown("6")){
			if(taFalando == false){
				taFalando = true;
				textoCompleto = false;
				StartCoroutine( AnimateText(textoT2) ); 
			}
		}
		if(Input.GetKeyDown("7")){
			if(taFalando == false){
				taFalando = true;
				textoCompleto = false;
				StartCoroutine( AnimateText(textoT3) ); 
			}
		}


	}

	public IEnumerator AnimateText(string strComplete){ 
		int i = 0;
		str = "";
		while( i < strComplete.Length ){ 
			str += strComplete[i++];

			if(i == strComplete.Length){
				textoCompleto = true;
			}
			texto.text = str;
			yield return new WaitForSeconds(0.05F); 
		} 
	}
}
