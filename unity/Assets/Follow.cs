using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {
	
	public Transform player;
	public Transform locationA;
	public Transform locationB;
	public float playerFocusDistance;
	private Vector3 target;
	private bool playerIsClose = false;
	private float playerDistance;
	// Use this for initialization
	void Start () {
		GetComponent<NavMeshAgent>().destination = locationA.position;
		target = locationA.position;
	}
	
	// Update is called once per frame
	void Update () {

		playerIsClose = CanSeePlayer();
		if(playerIsClose){
			if(GameObject.FindGameObjectWithTag("TeamOne") != null) {
				player = GameObject.FindGameObjectWithTag("TeamOne").transform;
				//animation.Play ("walk");
				GetComponent<NavMeshAgent>().destination = player.position;
			}
		} else {
			GetComponent<NavMeshAgent>().destination = target;
		}
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log("Here I am");

		if(target == locationA.position) {
			GetComponent<NavMeshAgent>().destination = locationB.position;
			target = locationB.position;
		} else {
			GetComponent<NavMeshAgent>().destination = locationA.position;
			target = locationA.position;
		}

	}

	bool CanSeePlayer() {
		playerDistance = Vector3.Distance(transform.position,player.position);
		if(playerDistance < playerFocusDistance) {
			return true;
		}
		return false;
	}
}
