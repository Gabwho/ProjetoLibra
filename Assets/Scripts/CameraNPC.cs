using UnityEngine;
using System.Collections;

public class CameraNPC : MonoBehaviour {

	private Camera camNPC;
	public Camera camOriginal;
	private GameObject locCam;
	private CameraClearFlags camFundo = CameraClearFlags.SolidColor;
	private Ray ray;
	private RaycastHit hit;
	private bool taFalando = false;
	private CaixadeTexto cxTexto;
	private GameObject gameController, caixadoTexto, player;
	private ControladorDeFalas falas;
	private Movement playerControl;

	void Start(){
		gameController = GameObject.Find ("GENERALCONTROLLER");
		falas = gameController.GetComponent<ControladorDeFalas> ();
		caixadoTexto = GameObject.FindGameObjectWithTag ("CaixaTexto");
		cxTexto = caixadoTexto.GetComponent<CaixadeTexto> ();
		player = GameObject.Find("Raphael");
		playerControl = player.GetComponent<Movement> ();
	}

	void OnTriggerStay(Collider other){
		if ((other.gameObject.tag == "NPC" && Input.touchCount > 0)) {

			ray = camOriginal.ScreenPointToRay(Input.GetTouch(0).position);

			if(Physics.Raycast (ray, out hit, 100f, 1 << LayerMask.NameToLayer("NPC")) && taFalando == false && Input.GetTouch(0).phase == TouchPhase.Began){
				CriaCameraNPC(other);
				cxTexto.NPCDiz("Elvira", 1);
				playerControl.setPodeAndar(false);
			}
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "NPC") {
			GameObject cameras = GameObject.Find("CameraNPC");
			Destroy(camNPC.gameObject);
			Destroy(cameras.gameObject);
			taFalando = false;
		}
	}

	void CriaCameraNPC(Collider other){
		taFalando = true;
		locCam = other.gameObject.transform.Find("PosicaoCamera").gameObject;
		camNPC = (Camera) Camera.Instantiate(camOriginal, locCam.transform.position, locCam.transform.rotation);
		Destroy(camNPC.GetComponent<AudioListener>());
		Destroy(camNPC.GetComponent<CameraController>());
		Debug.Log(locCam.transform.position);
		camNPC.gameObject.name = "CameraNPC";
		camNPC.rect = new Rect(0.75f, 0.25f, 0.25f, 0.5f);
		camNPC.clearFlags = camFundo;
		camNPC.backgroundColor = Color.black;
		camNPC.cullingMask = 1 << LayerMask.NameToLayer("NPC");
		camNPC.fieldOfView = 36;
		camNPC.depth = 1;
	}
}
