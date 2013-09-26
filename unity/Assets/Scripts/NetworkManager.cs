using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
	
	public string gameName = "melt nerf wars game";
	public GameObject playerPrefab;
	public Transform spawnObject;
	
	private float btnX;
	private float btnY;
	private float btnW;
	private float btnH;
	private bool refreshing = false;
	private HostData[] hostdata;
	

	// Use this for initialization
	void Start () {
		btnX = Screen.width * 0.05f;
		btnY = Screen.width * 0.05f;
		btnW = Screen.width * 0.05f;
		btnH = Screen.width * 0.05f;
	}
	
	void Update() {
		if(refreshing) {
			if(MasterServer.PollHostList().Length > 0) {
				refreshing = false;
				Debug.Log (MasterServer.PollHostList().Length);
				hostdata = MasterServer.PollHostList();
				
			}
		}
	}
	
	void startServer() {
		Network.InitializeServer(32,25001,!Network.HavePublicAddress());
		MasterServer.RegisterHost(gameName,"melt nerf wars","Melt nerf name!");
		
	}
	
	void refreshHostList() {
		MasterServer.RequestHostList(gameName);
		refreshing = true;
		
	}
	
	void spawnPlayer() {
		Network.Instantiate(playerPrefab,spawnObject.position,Quaternion.identity,0);
	}
	
	void OnServerInitialized() {
		Debug.Log ("Server Initialized");
		spawnPlayer();
	}
	
	void OnConnectedToServer() {
		spawnPlayer();
	}
	
	void OnMasterServerEvent(MasterServerEvent mse) {
		if(mse == MasterServerEvent.RegistrationSucceeded) {
			Debug.Log ("Registered Server");
		}
	}
	
	 IEnumerator wait(int timeToWait) {
        yield return new WaitForSeconds(timeToWait);
    }
	
	
	// GUI
	void OnGUI () {
		if(!Network.isClient && !Network.isServer) {
			if(GUI.Button(new Rect(btnX,btnY,btnW,btnH), "Start Server")) {
				Debug.Log ("Starting Server");
				startServer();
			}
			
			if(GUI.Button(new Rect(btnX,btnY * 1.2f + btnH,btnX,btnH), "Refresh Hosts")) {
				Debug.Log ("Refreshing");
				refreshHostList();
			}
			if(hostdata != null) {
				for(int i = 0; i<hostdata.Length;i++) {
					if(GUI.Button(new Rect(btnX * 1.5f + btnW,btnY*1.2f + (btnH * i),btnW*3f,btnH*.5f), hostdata[i].gameName)) {
						Network.Connect(hostdata[i]);
					}
				}
			}
		}
			
	}
}

