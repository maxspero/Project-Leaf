using UnityEngine;
using System.Collections;
using System;

public class PlayerInput : MonoBehaviour {
	bool trigger;

	void Start () {
		GetComponent<PlayerMovement> ();
		trigger = false;
	}

	void Update () {
		trigger = false;
		if(Input.GetKey(KeyCode.D)) {
			GetComponent<PlayerMovement> ().MoveRight();
			trigger = true;
		}
		if(Input.GetKey(KeyCode.A)) {
			GetComponent<PlayerMovement> ().MoveLeft();
			trigger = true;
		}
		if(Input.GetKey(KeyCode.S)) {
			GetComponent<PlayerMovement> ().MoveDown();
			trigger = true;
		}
		if(Input.GetKey(KeyCode.W)) {
			GetComponent<PlayerMovement> ().MoveUp();
			trigger = true;
		}
		if (!trigger){
			GetComponent<PlayerMovement> ().Stop ();
		}
	}
}
