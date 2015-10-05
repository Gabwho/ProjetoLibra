using UnityEngine;
using System.Collections;

public class SegueOutro : MonoBehaviour {

	public Transform followedPlayer;
	private int destPoint = 0;
	private NavMeshAgent agent;
	private Animator charAnimator;
	private GameObject personagem;
	private Movement movPerso;

	// Use this for initialization
	void Start () {
		movPerso = GameObject.Find ("Raphael").GetComponent<Movement> ();
		agent = GetComponent<NavMeshAgent>();
		personagem = gameObject;
		charAnimator = personagem.GetComponent<Animator> ();
		// Disabling auto-braking allows for continuous movement
		// between points (ie, the agent doesn't slow down as it
		// approaches a destination point).
		agent.autoBraking = false;

		Seguindo ();
	}

	void Seguindo(){
		agent.destination = followedPlayer.position;
		if (agent.remainingDistance >= 5f) {
			agent.speed = 10f;
		} else {
			agent.speed = 0f;
		}
	}
	
	// Update is called once per frame
	void Update () {
		Seguindo ();

		if (agent.speed != 0) {
			charAnimator.SetBool ("taAndando", true);
		} else {
			charAnimator.SetBool ("taAndando", false);
		}
	}
}
