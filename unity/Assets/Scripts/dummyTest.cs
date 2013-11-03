using UnityEngine;
using System.Collections;

public class dummyTest : MonoBehaviour {
	Animation anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animation>();
		anim.animation.Play("walk");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
