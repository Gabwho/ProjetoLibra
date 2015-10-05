using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {

	public GameObject ator;
	public bool caixa1ac = false, caixa2ac = false;
	public AbreSaida abriu;
	public GameObject trigger1, trigger2;

	void Start(){
		abriu = new AbreSaida ();
	}

	void FixedUpdate() {
		abriu = trigger1.GetComponent<AbreSaida> ();
		caixa1ac = abriu.tocou;
		abriu = trigger2.GetComponent<AbreSaida> ();
		caixa2ac = abriu.tocou;

		if(ator.transform.localPosition.y < 6.5 && caixa1ac == true && caixa2ac == true) {
			ator.transform.Translate (0, Time.deltaTime, 0, Space.World);
		}
	}
}