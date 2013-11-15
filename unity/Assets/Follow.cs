using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {
	
	private Transform player;
	// Use this for initialization
	void Start () {
		
		//player = GameObject.FindGameObjectWithTag("TeamOne").transform;
	
	}
	
	// Update is called once per frame
	void Update () {
		player = GameObject.FindGameObjectWithTag("TeamOne").transform;
		//animation.Play ("walk");
		GetComponent<NavMeshAgent>().destination = player.position;
	}
}
