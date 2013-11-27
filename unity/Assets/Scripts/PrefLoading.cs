using UnityEngine;
using System.Collections;

public class PrefLoading : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log("Game Type is Single: " + Globals.isSingle);
		if(!Globals.isSingle) {
			gameObject.AddComponent<NetworkManager>();
		}
		
		/**if(Globals.isMulti) {
			Instantiate(Resources.Load("SpawnLocationsTwoTeams"));
		} else {
			Instantiate(Resources.Load("SpawnLocationsOneTeam"));
			GameObject player = Instantiate(Resources.Load("First Person Controller")) as GameObject;
			Globals.assignPlayerToATeam(player);
		}**/
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
