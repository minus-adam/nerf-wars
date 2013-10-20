using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
	
	public GameObject fireEffect;
	float lifeSpan = 5;
	Vector3 lastVelocity;
	
	// Use this for initialization
	void Start () {
		
	}
	
	void Update() {
		lifeSpan -= Time.deltaTime;
		if(lifeSpan <= 0) {
			Destroy(gameObject);	
		}
	}
	
	void FixedUpdate() {
    lastVelocity = gameObject.rigidbody.velocity;
	}
	
	// Update is called once per frame
	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag == "Table") {
			Vector3 location = collision.transform.position;
			location.y = 3;
			Instantiate(fireEffect, location, Quaternion.identity);
		}
		
		if(collision.gameObject.tag == "Monitor") {
			Debug.Log("Hi");
			var stickyJoint = gameObject.AddComponent<FixedJoint>();
			stickyJoint.connectedBody = collision.rigidbody;
		}
		
	}

}
