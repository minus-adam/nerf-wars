using UnityEngine;
using System.Collections;

public class Globals : MonoBehaviour {

	public static bool isSingle = true;
	public static bool isCo = false;
	public static bool isMulti = false;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
