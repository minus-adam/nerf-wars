using UnityEngine;
using System.Collections;

public class GUICrosshair : MonoBehaviour {
	
	public Texture2D crosshairTexture;
	private Rect position;
	private static bool originalOn = true;

	// Use this for initialization
	void Start () {
	position = new Rect((Screen.width - crosshairTexture.width) / 2, (Screen.height - 
        crosshairTexture.height) /2, crosshairTexture.width, crosshairTexture.height);
	}
	
	void OnGUI () {
		if(originalOn == true)
	    {
	        GUI.DrawTexture(position, crosshairTexture);
	    }
	}
}

   
 
