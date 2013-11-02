using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {
	
	public GameObject[] spawnLocationsTeamOne;
	public GameObject[] spawnLocationsTeamTwo;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public Transform getSpawnLocation() {
		if(!Globals.isMulti) {
			int spawnIndex = Random.Range(0,spawnLocationsTeamOne.Length);
			return spawnLocationsTeamOne[spawnIndex].transform;
		}
		return null;

	}
	
	public Transform getSpawnLocation(Globals.TEAMS team) {
		if(team == Globals.TEAMS.ONE) {
			int spawnIndex = Random.Range(0,spawnLocationsTeamOne.Length);
			return spawnLocationsTeamOne[spawnIndex].transform;	
		} else {
			int spawnIndex = Random.Range(0,spawnLocationsTeamTwo.Length);
			return spawnLocationsTeamTwo[spawnIndex].transform;	
		}
		return null;
		
	}
}
