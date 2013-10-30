using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
	
	float lifeSpan = 5;
	public Transform shooter;
	
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
			var stickyJoint = gameObject.AddComponent<FixedJoint>();
			stickyJoint.connectedBody = collision.rigidbody;
		}
		
		if(collision.gameObject.tag == "Enemy" ) {
			collision.gameObject.GetComponent<Enemy>().health -= 1;
			shooter.GetComponent<PlayerInfo>().AddHit();
			shooter.GetComponent<PlayerInfo>().UpdateHitAccuracy();
			if(collision.gameObject.GetComponent<Enemy>().health <= 0) {
				Destroy(collision.gameObject);
				shooter.GetComponent<PlayerInfo>().AddKill();
			}
		}
		
	}

}
