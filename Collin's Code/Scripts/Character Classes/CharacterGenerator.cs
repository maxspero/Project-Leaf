using UnityEngine;
using System.Collections;
using System;

public class CharacterGenerator : MonoBehaviour {
	private PlayerCharacter toon;
	private const int STARTING_POINTS = 35;
	private const int MIN_STARTING_ATTRIBUTE_VALUE = 1;
	private const int STARTING_ATTRIBUTE_VALUE = 5;
	private int pointsLeft;

	private const int OFFSET = 5;
	private const int LINE_HEIGHT = 20;
	
	private const int STAT_LABEL_WIDTH = 100;
	private const int BASEVALUE_LABEL_WIDTH = 30;
	private const int BUTTON_WIDTH = 20;
	private const int BUTTON_HEIGHT = 20;

	private const int STAT_STARTING_POSITION = 40;

	public GUIStyle myStyle;

	public GameObject playerPrefab;
	// Use this for initialization
	void Start () {
		GameObject pcharacter = Instantiate (playerPrefab, Vector3.zero, Quaternion.identity) as GameObject;
		pcharacter.GetComponent<Transform> ().localScale = new Vector3(2, 2, 1);
		pcharacter.name = "pc";
		//toon = new PlayerCharacter ();
		//toon.Awake ();
		toon = pcharacter.GetComponent<PlayerCharacter> ();
		pointsLeft = STARTING_POINTS;
		SetBeginningAttributes ();
		toon.StatUpdate ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnGUI() {
		DisplayName ();
		DisplayAttributes ();
		DisplayVitals ();
		DisplaySkills ();
		DisplayPointsLeft ();
		DisplaySecondaryAttributes ();

		if(toon.Name == "" || pointsLeft > 0)
			DisplayCreateLabel ();
		else 
			DisplayCreateButton ();
	}

	private void DisplayName() {
		GUI.Label (new Rect(10, 10, 50, 25), "Name: ");
		toon.Name = GUI.TextField (new Rect (65, 10, 100, 25), toon.Name);
	}

	private void DisplayAttributes() {
		for(int i = 0; i < Enum.GetValues(typeof(AttributeName)).Length; i++) {
			GUI.Label(new Rect(OFFSET, STAT_STARTING_POSITION + (i * LINE_HEIGHT), STAT_LABEL_WIDTH, LINE_HEIGHT), ((AttributeName)i).ToString());
			GUI.Label(new Rect(STAT_LABEL_WIDTH + OFFSET + BASEVALUE_LABEL_WIDTH, STAT_STARTING_POSITION + (i * LINE_HEIGHT), BASEVALUE_LABEL_WIDTH, LINE_HEIGHT), toon.GetPrimaryAttribute(i).AdjustedBaseValue.ToString());
			if(GUI.Button(new Rect(OFFSET + STAT_LABEL_WIDTH + BASEVALUE_LABEL_WIDTH + BUTTON_WIDTH, STAT_STARTING_POSITION + (i *BUTTON_HEIGHT), BUTTON_WIDTH, BUTTON_HEIGHT), "-")) {
				if(toon.GetPrimaryAttribute(i).BaseValue > MIN_STARTING_ATTRIBUTE_VALUE) {
					toon.GetPrimaryAttribute(i).BaseValue--;
					pointsLeft++;
					toon.StatUpdate ();
				}
			}
			if(GUI.Button(new Rect(OFFSET + STAT_LABEL_WIDTH + BUTTON_WIDTH * 2 + BASEVALUE_LABEL_WIDTH, STAT_STARTING_POSITION + (i *BUTTON_HEIGHT), BUTTON_WIDTH, BUTTON_WIDTH), "+")) {
				if(pointsLeft > 0) {
					toon.GetPrimaryAttribute(i).BaseValue++;
					pointsLeft--;
					toon.StatUpdate ();
				}
			}
		}
	}

	private void DisplayVitals() {
		for(int i = 0; i < Enum.GetValues(typeof(VitalName)).Length; i++) {
			GUI.Label(new Rect(OFFSET, STAT_STARTING_POSITION + ((i + 5) * LINE_HEIGHT), STAT_LABEL_WIDTH, LINE_HEIGHT), ((VitalName)i).ToString());
			GUI.Label(new Rect(STAT_LABEL_WIDTH + OFFSET, STAT_STARTING_POSITION + ((i + 5) * LINE_HEIGHT), BASEVALUE_LABEL_WIDTH, LINE_HEIGHT), toon.GetVital(i).AdjustedBaseValue.ToString());
		}
	}

	private void DisplaySkills() {
		for(int i = 0; i < Enum.GetValues(typeof(SkillName)).Length; i++) {
			GUI.Label(new Rect(OFFSET + STAT_LABEL_WIDTH + BUTTON_WIDTH * 2 + BASEVALUE_LABEL_WIDTH * 2 + OFFSET, STAT_STARTING_POSITION + (i * LINE_HEIGHT), STAT_LABEL_WIDTH, LINE_HEIGHT), ((SkillName)i).ToString());
			GUI.Label(new Rect(OFFSET + STAT_LABEL_WIDTH * 2 + BUTTON_WIDTH * 2 + BASEVALUE_LABEL_WIDTH * 2 + OFFSET, STAT_STARTING_POSITION + (i * LINE_HEIGHT), BASEVALUE_LABEL_WIDTH, LINE_HEIGHT), toon.GetSkill(i).AdjustedBaseValue.ToString());
		}
	}

	private void DisplaySecondaryAttributes() {
		for(int i = 0; i < Enum.GetValues(typeof(SecondaryAttributeName)).Length; i++) {
			GUI.Label(new Rect(OFFSET + STAT_LABEL_WIDTH * 2 + BUTTON_WIDTH * 2 + BASEVALUE_LABEL_WIDTH * 3 + OFFSET, STAT_STARTING_POSITION + (i * LINE_HEIGHT), STAT_LABEL_WIDTH, LINE_HEIGHT), ((SecondaryAttributeName)i).ToString());
			GUI.Label(new Rect(OFFSET + STAT_LABEL_WIDTH * 3 + BUTTON_WIDTH * 2 + BASEVALUE_LABEL_WIDTH * 4 + OFFSET, STAT_STARTING_POSITION + (i * LINE_HEIGHT), BASEVALUE_LABEL_WIDTH, LINE_HEIGHT), toon.GetSecondaryAttribute(i).AdjustedBaseValue.ToString());
		}
	}

	private void SetBeginningAttributes() {
		for (int i = 0; i < Enum.GetValues(typeof(AttributeName)).Length; i++) {
			toon.GetPrimaryAttribute (i).BaseValue = STARTING_ATTRIBUTE_VALUE;
			pointsLeft -= STARTING_ATTRIBUTE_VALUE;
		}
	}

	private void DisplayPointsLeft() {
		GUI.Label (new Rect (250, 10, 100, 25), "Points Left: " + pointsLeft.ToString());
	}

	private void DisplayCreateButton() {
		if (GUI.Button (new Rect (OFFSET, STAT_STARTING_POSITION + (8 * LINE_HEIGHT) + OFFSET, STAT_LABEL_WIDTH, LINE_HEIGHT), "Create")) {
			GameSettings gsScript = GameObject.Find("gameSettings").GetComponent<GameSettings>();
			UpdateCurVitalValues();
			gsScript.SaveCharacterData();
			Application.LoadLevel("Level 1");
		}
	}

	private void DisplayCreateLabel() {
		GUI.Label (new Rect (OFFSET, STAT_STARTING_POSITION + (8 * LINE_HEIGHT) + OFFSET, STAT_LABEL_WIDTH, LINE_HEIGHT), "Create", "Button");
	}

	private void UpdateCurVitalValues() {
		for (int i = 0; i < Enum.GetValues(typeof(VitalName)).Length; i++) {
			toon.GetVital(i).CurValue = toon.GetVital(i).AdjustedBaseValue;
		}
	}
}
