using UnityEngine;
using System.Collections;

public class Globals : MonoBehaviour {

	public static bool isSingle = true;
	public static bool isCo = false;
	public static bool isMulti = false;
	public enum TEAMS {ONE,TWO};
	public static ArrayList teamOne = new ArrayList();
	public static ArrayList teamTwo = new ArrayList();
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public static void assignPlayerToATeam(GameObject player) {
		// check if team is full
		// add to team, make sure teams are even
		if(teamOne.Count > teamTwo.Count) {
			player.tag = Tags.TEAMTWO;
			teamTwo.Add(player);
		} else {
			player.tag = Tags.TEAMONE;
			teamOne.Add(player);
		}

		
	}
}
