using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class SonsPassosJogador : MonoBehaviour {

	private AudioSource contrAudio;
	public bool areia, floresta, caverna, casa; 
	private Animator aniChar;
	private float duracao;
	public AudioClip[] passoAreia, passoFloresta, passoCaverna, passoCasa;

	// Use this for initialization
	void Awake () {
		aniChar = GetComponent<Animator> ();
		contrAudio = GetComponent<AudioSource> ();
		contrAudio.volume = 0.5f;
	}
	
	// Update is called once per frame
	IEnumerator Start () {
		while (true) {
			if (aniChar.GetBool ("taAndando")) {
				if (areia) {
					contrAudio.clip = passoAreia [Random.Range (0, passoAreia.Length)];
					contrAudio.PlayOneShot (contrAudio.clip);
				}
				if (floresta) {
					contrAudio.clip = passoFloresta [Random.Range (0, passoFloresta.Length)];
					contrAudio.PlayOneShot (contrAudio.clip);
				}
				if(caverna){
					contrAudio.clip = passoCaverna [Random.Range (0, passoCaverna.Length)];
					contrAudio.PlayOneShot (contrAudio.clip);
				}
				if(casa){
					contrAudio.clip = passoCasa [Random.Range (0, passoCasa.Length)];
					contrAudio.PlayOneShot (contrAudio.clip);
				}
			}
		
			yield return new WaitForSeconds (0.4f);
		}
	}
}
