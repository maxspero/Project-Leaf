using UnityEngine;
using System.Collections;
using System;

public class ControlsMenu : MonoBehaviour {
	private const int OFFSET = 400;
	private const int LINE_HEIGHT = 50;
	private const int PANEL_OFFSET = 350;
	
	private const int KEY_LABEL_WIDTH = 500;
	private const int KEY_INPUT_LABEL_WIDTH = 75;
	private const int BUTTON_WIDTH = 20;
	private const int BUTTON_HEIGHT = 20;
	private const int KEY_STARTING_POSITION = 0;
	private string[] keys;
	// Use this for initialization
	void Start () {
		keys = new string[Enum.GetValues(typeof(Keys)).Length];
	}
	
	// Update is called once per frame
	void Update () {
		//GetComponent<RectTransform>().localPosition.y
	}

	void OnGUI() {
		DisplayKeys ();
	}

	private void DisplayKeys() {
		for (int i = 0; i < Enum.GetValues(typeof(Keys)).Length; i++) {
			GUI.Label(new Rect(OFFSET, KEY_STARTING_POSITION + (i * LINE_HEIGHT) - PANEL_OFFSET - GetComponent<RectTransform>().localPosition.y, KEY_LABEL_WIDTH, LINE_HEIGHT), ((Keys)i).ToString());
			keys[i] = PlayerPrefs.GetString(((Keys)i).ToString(), "");
			keys[i] = GUI.TextField(new Rect(OFFSET + KEY_LABEL_WIDTH, KEY_STARTING_POSITION + (i * LINE_HEIGHT) - GetComponent<RectTransform>().localScale.y - PANEL_OFFSET - GetComponent<RectTransform>().localPosition.y, KEY_INPUT_LABEL_WIDTH,LINE_HEIGHT), keys[i]);
			PlayerPrefs.SetString(((Keys)i).ToString(), keys[i]);
		}
	}
}

public enum Keys {
	Up,
	Down,
	Left,
	Right,
	Jump,
	Attack,
	Action_Bar_1,
	Action_Bar_2,
	Action_Bar_3,
	Action_Bar_4,
	Action_Bar_5,
	Action_Bar_6,
	Action_Bar_7,
	Action_Bar_8,
	Action_Bar_9,
	Action_Bar_10,
	Open_Inventory,
	Open_Character_Window
}
