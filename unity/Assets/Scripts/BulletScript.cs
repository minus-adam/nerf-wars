using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
	
	float lifeSpan = 5;
	public Transform shooter;
	private string enemyTeam;
	private string shooterTeam;
	
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
		if(shooter != null) {
			if(shooter.tag == Tags.TEAMONE) {
				enemyTeam = Tags.TEAMTWO;
			} else if (shooter.tag == Tags.TEAMTWO) {
				enemyTeam = Tags.TEAMONE;
			}
			
			if(collision.gameObject.tag == "Monitor") {
				var stickyJoint = gameObject.AddComponent<FixedJoint>();
				stickyJoint.connectedBody = collision.rigidbody;
			}
			
			if(collision.gameObject.tag == enemyTeam ) {
				Debug.Log (enemyTeam + " player hit");
				collision.gameObject.GetComponent<Enemy>().health -= 1;
				shooter.GetComponent<PlayerInfo>().AddHit();
				shooter.GetComponent<PlayerInfo>().UpdateHitAccuracy();
				if(collision.gameObject.GetComponent<Enemy>().health <= 0) {
					Destroy(collision.gameObject);
					shooter.GetComponent<PlayerInfo>().AddKill();
				}
				Destroy(gameObject);
			}
		}
		
	}

}
