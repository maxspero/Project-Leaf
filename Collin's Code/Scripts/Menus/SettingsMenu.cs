using UnityEngine;
using System.Collections;

public class SettingsMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		if (GUI.Button (new Rect (5, 5, 500, 50), "Change Controls")) {
			Application.LoadLevel("Keys");
		}
	}
}
