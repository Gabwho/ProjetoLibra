using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Patrulha : MonoBehaviour {

	public Transform[] points;
	private int destPoint = 0;
	private NavMeshAgent agent;
	private Animator charAnimator;
	private GameObject personagem;
	private Movement movPrinc;
	Ray visionRay;
	RaycastHit visionHit;
	bool viuPlayer = false;
	bool foiPego = false;
	private ControladorDeCenas gnrCont;
	private GameObject generalController;

	private AudioSource contrAudio;
	public AudioClip somVisto;

	void Start () {
		contrAudio = GetComponent<AudioSource> ();
		contrAudio.volume = 1f;
		contrAudio.clip = somVisto;
		
		generalController = GameObject.Find ("GENERALCONTROLLER");
		gnrCont = generalController.GetComponent<ControladorDeCenas> ();

		movPrinc = GameObject.Find ("Raphael").GetComponent<Movement> ();
		agent = GetComponent<NavMeshAgent>();
		personagem = gameObject;
		charAnimator = personagem.GetComponent<Animator> ();
		// Disabling auto-braking allows for continuous movement
		// between points (ie, the agent doesn't slow down as it
		// approaches a destination point).
		agent.autoBraking = false;
		movPrinc.setPodeAndar(true);
		GotoNextPoint();
	}
	
	void GotoNextPoint() {
		// Returns if no points have been set up
		if (points.Length == 0)
			return;
		
		// Set the agent to go to the currently selected destination.
		agent.destination = points[destPoint].position;
		
		// Choose the next point in the array as the destination,
		// cycling to the start if necessary.
		destPoint = (destPoint + 1) % points.Length;
		agent.speed = 7;
		StopAllCoroutines ();
	}
	
	
	void Update () {
		// Choose the next destination point when the agent gets
		// close to the current one.
		if (agent.remainingDistance < 0.5f && viuPlayer == false) {
			StartCoroutine (Loop ());
		}
		if (agent.speed != 0 && viuPlayer == false) {
			charAnimator.SetBool ("isWalking", true);
		}

		visionRay.origin = transform.position;
		visionRay.direction = transform.forward;

		if(Physics.SphereCast(visionRay, 5f, out visionHit, 35) && viuPlayer == false){
			if(visionHit.collider.tag == "Player"){
				viuPlayer = true;
				contrAudio.Play();
				ParaPlayer(visionHit.collider.transform.position);
			}
		}
	}

	void ParaPlayer(Vector3 position){
		StopAllCoroutines ();
		if (charAnimator.GetBool ("isRunning") == false) {
			agent.speed = 14;
			agent.destination = position;
			agent.updateRotation = true;
			charAnimator.SetBool ("isWalking", false);
			charAnimator.SetBool ("isRunning", true);
			movPrinc.setPodeAndar (false);
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player" && viuPlayer) {
			agent.speed = 0;
			charAnimator.SetBool ("isRunning", false);
			agent.Stop ();
			gnrCont.FadeAndReload(Color.black);
		}
	}

	IEnumerator Loop(){
		agent.speed = 0;
		charAnimator.SetBool ("isWalking", false);
		yield return new WaitForSeconds(3);
		GotoNextPoint ();	
	}
}

