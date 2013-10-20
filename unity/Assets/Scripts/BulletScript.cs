using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
	
	public GameObject fireEffect;
	float lifeSpan = 5;
	
	// Use this for initialization
	void Start () {
		
	}
	
	void Update() {
		lifeSpan -= Time.deltaTime;
		if(lifeSpan <= 0) {
			Destroy(gameObject);	
		}
	}
	
	
	// Update is called once per frame
	void OnCollisionEnter(Collision collision) {
		
		if(collision.gameObject.tag == "Monitor") {
			Debug.Log("Hi");
			var stickyJoint = gameObject.AddComponent<FixedJoint>();
			stickyJoint.connectedBody = collision.rigidbody;
		}
		
	}

}
