using UnityEngine;
using System.Collections;
using System;

public class Mob : BaseCharacter {

	// Use this for initialization
	void Start () {
		for (int i = 0; i < Enum.GetValues(typeof(AttributeName)).Length; i++) {
			GetPrimaryAttribute(i).BaseValue = 1;
		}
		StatUpdate ();
		for (int i = 0; i < Enum.GetValues(typeof(VitalName)).Length; i++) {
			GetVital(i).Set();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
