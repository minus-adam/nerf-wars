using UnityEngine;
using System.Collections;

public class EnemyShootingScript : MonoBehaviour {
	
	public Follow follow;
	public float shootingDistance;
	private float playerDistance;
	
	public GameObject bullet_prefab;
	public float bulletImpulse = 40f;
	public int bulletMax = 5;
	private int bulletCount;
	public Transform shooter;
	public GameObject gun;
	private float damping = 6.0f;
	private bool canShoot = true;
	public float shootingRefresh = 1f;
	// Use this for initialization
	void Awake () {
		follow = GetComponent<Follow>();
		bulletCount = bulletMax;
	}
	
	// Update is called once per frame
	void Update () {
		follow = GetComponent<Follow>();
		if(bulletCount > bulletMax) {
			bulletCount = bulletMax;
		}
		if(follow.player != null) {
			var rotation = Quaternion.LookRotation(follow.player.position - gun.transform.position);
			gun.transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
			
			playerDistance = Vector3.Distance(transform.position,follow.player.position);
			if(playerDistance < shootingDistance) {
				if(bulletCount > 0 && canShoot) {
					Debug.Log ("Get Here");
				
				GameObject thebullet = (GameObject)Instantiate(bullet_prefab, gun.transform.position + gun.transform.forward *3, gun.transform.rotation);
				thebullet.rigidbody.AddForce( gun.transform.forward * bulletImpulse, ForceMode.Impulse);
				thebullet.GetComponent<BulletScript>().shooter = shooter;
				gameObject.GetComponent<PlayerInfo>().AddShotTaken();
				bulletCount--;
				canShoot = false;
				}
				if(!canShoot) {
					shootingRefresh -= Time.deltaTime;
					if(shootingRefresh <= 0) {
						canShoot = true;
						shootingRefresh = 3f;
					}
				}
			}
		}
	
	}
}
