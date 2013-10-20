using UnityEngine;
using System.Collections;

public class AmmoTriggerZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider collider) {
		Debug.Log ("Hello On Trigger");
		if(collider.gameObject.tag == "Player") {
			bool addAmmo = collider.GetComponent<ShootingScript>().addAmmo();
			if(addAmmo) {
				Destroy(gameObject);
			}
		}

	}
}
