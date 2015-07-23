using UnityEngine;
using System.Collections;
using System;

public class GameSettings : MonoBehaviour {

	void Awake() {
		DontDestroyOnLoad (this);
	}

	public void SaveCharacterData() {
		GameObject pcharacter = GameObject.Find ("pc");
		PlayerCharacter pcClass = pcharacter.GetComponent<PlayerCharacter> ();
		PlayerPrefs.SetString ("Player Name", pcClass.Name);

		for (int i = 0; i < Enum.GetValues(typeof(AttributeName)).Length; i++) {
			PlayerPrefs.SetInt (((AttributeName)i).ToString() + " - Base Value", pcClass.GetPrimaryAttribute(i).BaseValue);
		}
		for (int i = 0; i < Enum.GetValues(typeof(VitalName)).Length; i++) {
			PlayerPrefs.SetInt (((VitalName)i).ToString() + " - Base Value", pcClass.GetVital(i).AdjustedBaseValue);
			PlayerPrefs.SetInt (((VitalName)i).ToString() + " - Current Value", pcClass.GetVital(i).CurValue);
		}
		for (int i = 0; i < Enum.GetValues(typeof(SkillName)).Length; i++) {
			PlayerPrefs.SetInt(((SkillName)i).ToString() + " - Base Value", pcClass.GetSkill(i).AdjustedBaseValue);
		}
	}

	public void LoadCharacterData() {
		GameObject pcharacter = GameObject.Find ("pc");
		PlayerCharacter pcClass = pcharacter.GetComponent<PlayerCharacter> ();
		pcClass.Name = PlayerPrefs.GetString ("Player Name", "Name Me");
		for (int i = 0; i < Enum.GetValues(typeof(AttributeName)).Length; i++) {
			pcClass.GetPrimaryAttribute(i).BaseValue = PlayerPrefs.GetInt(((AttributeName)i).ToString() + " - Base Value", 0);
		}

		for (int i = 0; i < Enum.GetValues(typeof(VitalName)).Length; i++) {
			pcClass.GetVital(i).BaseValue = PlayerPrefs.GetInt (((VitalName)i).ToString() + " - Base Value", 0);
			pcClass.GetVital(i).CurValue = PlayerPrefs.GetInt (((VitalName)i).ToString() + " - Current Value", 0);
		}

		for (int i = 0; i < Enum.GetValues(typeof(SkillName)).Length; i++) {
			pcClass.GetSkill(i).BaseValue = PlayerPrefs.GetInt(((SkillName)i).ToString() + " - Base Value", 0);
		}
	}
}
