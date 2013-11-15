using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {
	
	public Transform player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(GameObject.FindGameObjectWithTag("TeamOne") != null) {
			player = GameObject.FindGameObjectWithTag("TeamOne").transform;
			//animation.Play ("walk");
			GetComponent<NavMeshAgent>().destination = player.position;
		}
	}
}
