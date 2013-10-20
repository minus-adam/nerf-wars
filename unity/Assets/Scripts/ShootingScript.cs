using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour {
	
	public GameObject bullet_prefab;
	public float bulletImpulse = 20f;
	public int bulletMax = 5;
	private int bulletCount;
	 

	// Use this for initialization
	void Start () {
		bulletCount = bulletMax;
	}
	
	// Update is called once per frame
	void Update () {
		if(bulletCount > bulletMax) {
			bulletCount = bulletMax;
		}
		if( Input.GetButtonDown("Fire1") ) {
			if(bulletCount > 0) {
				Camera cam = Camera.main;
				GameObject thebullet = (GameObject)Instantiate(bullet_prefab, cam.transform.position + cam.transform.forward *3, cam.transform.rotation);
				thebullet.rigidbody.AddForce( cam.transform.forward * bulletImpulse, ForceMode.Impulse);
				bulletCount--;
			}
		}
			
	}
		
	void OnGUI() {
		GUI.Label(new Rect( 450,5, 30,30),"X "+bulletCount);
	}
	
	public bool addAmmo() {
		if(bulletCount <= 5) {
			bulletCount += 5;
			return true;
		}
		return false;
	}

}
