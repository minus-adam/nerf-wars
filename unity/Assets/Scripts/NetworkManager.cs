using UnityEngine;
using System.Collections;

public class NetworkManager : Photon.MonoBehaviour {
	
	private Vector3 spawnLocation = new Vector3(-42.75074f,5.6206f,-8.175415f);
	
	
	void Start() {
		PhotonNetwork.ConnectUsingSettings("alpha 0.1");
		
	}
	
	void OnGUI() {
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
	}
	
	void OnJoinedLobby() {
		PhotonNetwork.JoinRandomRoom();
	}
	
	void OnPhotonRandomJoinFailed() {
		PhotonNetwork.CreateRoom(null);
		
	}
	
	void OnJoinedRoom() {
		//GameObject myPlayer = PhotonNetwork.Instantiate("First Person Controller",spawnLocation, Quaternion.identity,0);	
	}
	
}
