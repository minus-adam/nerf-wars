using UnityEngine;
using System.Collections;

public class PrefLoading : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log("Game Type is Single: " + Globals.isSingle);
		if(!Globals.isSingle) {
			gameObject.AddComponent<NetworkManager>();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
