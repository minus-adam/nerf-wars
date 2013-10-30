using UnityEngine;
using System.Collections;

public class PlayerInfo : MonoBehaviour {
	
	public int hitPoints = 5;
	private int shotsTaken = 0;
	private int hits = 0;
	private double hitAccuracy = 0;
	private int kills = 0;
 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void AddHit() {
		hits += 1;
	}
	
	public void AddShotTaken() {
		shotsTaken += 1;
		UpdateHitAccuracy();
	}
	
	public void AddKill() {
		kills += 1;
	}
	
	public void UpdateHitAccuracy() {
		if(shotsTaken > 0) {
			hitAccuracy = (100 *hits / shotsTaken);
		} else {
			hitAccuracy = 0;
		}
	}
}
