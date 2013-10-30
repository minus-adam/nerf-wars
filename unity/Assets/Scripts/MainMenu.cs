using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	public bool isSingle = false;
	public bool isCo = false;
	public bool isMultiPlayer = false;
	public bool isQuit = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseEnter() {
		renderer.material.color = Color.red;
	}
	
	void OnMouseExit() {
	renderer.material.color = Color.white;
	}
	
	void OnMouseUp() {
		if (isQuit) {
			Application.Quit();
		}
		
		if (isSingle) {
			Globals.isSingle = true;
			Globals.isCo = false;
			Globals.isMulti = false;
			Application.LoadLevel(1);
		}
		
		if (isCo) {
			Globals.isSingle = false;
			Globals.isCo = true;
			Globals.isMulti = false;
			Application.LoadLevel(1);
		}
		
		if (isMultiPlayer) {
			Globals.isSingle = false;
			Globals.isCo = false;
			Globals.isMulti = true;
			Application.LoadLevel(1);
		}
	}
}
