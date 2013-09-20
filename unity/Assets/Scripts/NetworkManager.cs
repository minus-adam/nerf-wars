using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
	
	private string gameName = "melt nerf wars game";
	private float btnX;
	private float btnY;
	private float btnW;
	private float btnH;
	// Use this for initialization
	void Start () {
		btnX = Screen.width * 0.05f;
		btnY = Screen.width * 0.05f;
		btnW = Screen.width * 0.05f;
		btnH = Screen.width * 0.05f;
	}
	
	
	void startServer() {
		Network.InitializeServer(32,25001,Network.HavePublicAddress());
		MasterServer.RegisterHost(gameName,"melt nerf wars","Melt nerf name!");
		
	}
	
	void OnServerInitialized() {
		Debug.Log ("Server Initialized");
	}
	
	void OnMasterServerEvent(MasterServerEvent mse) {
		if(mse == MasterServerEvent.RegistrationSucceeded) {
			Debug.Log ("Registered Server");
		}
	}
	
	void OnGUI () {
		if(GUI.Button(new Rect(btnX,btnY,btnX,btnH), "Start Server")) {
			Debug.Log ("Starting Server");
			startServer();
		}
		
		if(GUI.Button(new Rect(btnX,btnY * 1.2f + btnH,btnX,btnH), "Refresh Hosts")) {
			Debug.Log ("Refreshing");
		}
	}
}
