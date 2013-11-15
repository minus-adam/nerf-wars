using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour {
	
	public float fieldOfView = 110f;
	public bool playerInSight;
	public Vector3 personalLastSighting;
	
	private NavMeshAgent nav;
	private SphereCollider col;
	private Animator anim;
	//private LastPlayerSighting lastPlayerSighting;
	private GameObject player;
	private Animator playerAnim;
	private PlayerInfo playerInfo;
	private Vector3 previousSighting;
	
	// Use this for initialization
	void Awake () {
		nav = GetComponent<NavMeshAgent>();
		col = GetComponent<SphereCollider>();
		anim = GetComponent<Animator>();
		//lastPlayerSighting = GameObject.FindGameObjectWithTag(Tags.TEAMONE).GetComponent<Las
		player = GameObject.FindGameObjectWithTag(Tags.TEAMONE);
//		playerAnim = player.GetComponent<Animator>();
//		playerInfo = player.GetComponent<PlayerInfo>();
	}
	
	// Update is called once per frame
	void Update () {
		
		//if(lastPlayerSighting != previousSighting) {
			//personalLastSighting = lastPlayerSighting.position;
	//	}
	
	}
}
