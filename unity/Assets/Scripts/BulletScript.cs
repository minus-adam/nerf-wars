using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
	
	public GameObject fireEffect;
	float lifeSpan = 3.0f;
	Vector3 lastVelocity;
	
	// Use this for initialization
	void Start () {
		
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
			ContactPoint contact = collision.contacts[0];
			gameObject.rigidbody.isKinematic = true;
			transform.position = contact.point - lastVelocity.normalized;
		}
		
	}

}
