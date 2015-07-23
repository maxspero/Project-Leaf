using UnityEngine;
using System.Collections;
using System;

public class PlayerInput : MonoBehaviour {


	void Start () {
		GetComponent<PlayerMovement> ();
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)) {
			Application.LoadLevel("Settings Menu");
		}
		if(Input.GetKey(PlayerPrefs.GetString("Right"))) {
			GetComponent<PlayerMovement> ().MoveRight();
		}
		else if(Input.GetKey(PlayerPrefs.GetString("Left"))) {
			GetComponent<PlayerMovement> ().MoveLeft();
		}
		else {
			GetComponent<PlayerMovement> ().Stop ();
		}
	}
}
