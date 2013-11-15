using UnityEngine;
using System.Collections;

public class StatScreen : MonoBehaviour {
	
	private Color newColor;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnGUI() {
		
		GUI.Box(new Rect(0,Screen.height - 300,400,300),"Future location for the teams scores.");
	}
}
