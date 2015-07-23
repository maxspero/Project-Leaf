using UnityEngine;
using System.Collections;
using System;

public class BaseCharacter : MonoBehaviour {
	private string _name;
	private int level;
	private uint freeExp; //0 - 4.2 billion

	private Attribute[] primaryAttribute;
	private Vital[] vital;
	private Skill[] skill;
	private SecondaryAttribute[] secondaryAttribute;

	public void Awake() {
		_name = string.Empty;
		level = 0;
		freeExp = 0;

		primaryAttribute = new Attribute[Enum.GetValues(typeof(AttributeName)).Length];
		vital = new Vital[Enum.GetValues(typeof(VitalName)).Length];
		skill = new Skill[Enum.GetValues(typeof(SkillName)).Length];
		secondaryAttribute = new SecondaryAttribute[Enum.GetValues(typeof(SecondaryAttributeName)).Length];

		SetupPrimaryAttributes ();
		SetupVitals ();
		SetupSkills ();
		SetupSecondaryAttributes ();
	}

	public string Name {
		get{ return _name; }
		set{ _name = value; }
	}

	public int Level {
		get{ return level; }
		set{ level = value; }

	}

	public uint FreeExp {
		get{ return freeExp; }
		set{ freeExp = value; }
	}

	public void AddExp(uint exp){
		freeExp += exp;
		CalculateLevel ();
	}

	public void CalculateLevel() {

	}

	private void SetupPrimaryAttributes() {
		for (int i = 0; i < primaryAttribute.Length; i++) {
			primaryAttribute[i] = new Attribute();
			primaryAttribute[i].Name = ((AttributeName)i).ToString();
		}
	}

	private void SetupVitals() {
		for (int i = 0; i < vital.Length; i++) {
			vital[i] = new Vital();
		}
		SetupVitalModifiers ();
	}
	
	private void SetupSkills() {
		for (int i = 0; i < skill.Length; i++) {
			skill[i] = new Skill();
		}
		SetupSkillModifier ();
	}

	private void SetupSecondaryAttributes() {
		for (int i = 0; i < secondaryAttribute.Length; i++) {
			secondaryAttribute[i] = new SecondaryAttribute();
		}
		SetupSecondaryAttributeModifier ();
	}

	public Attribute GetPrimaryAttribute(int index) {
		return primaryAttribute[index];
	}

	public Vital GetVital(int index) {
		return vital[index];
	}

	public Skill GetSkill(int index) {
		return skill[index];
	}

	public SecondaryAttribute GetSecondaryAttribute(int index) {
		return secondaryAttribute [index];
	}

	private void SetupVitalModifiers() {
		//health
		GetVital ((int)VitalName.Health).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Vitality), 80.0f));
		GetVital ((int)VitalName.Health).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Strength), 20.0f));

		//energy
		GetVital ((int)VitalName.Energy).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Vitality), 30.0f));
		GetVital ((int)VitalName.Energy).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Agility), 5.0f));

		//mana
		GetVital ((int)VitalName.Mana).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Intelligence), 30.0f));
		GetVital ((int)VitalName.Mana).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Vitality), 5.0f));
	}

	private void SetupSkillModifier() {
		//Trainer/Tome Upgradeable
		//One_Handed_Weapons
		//Two_Handed_Weapons
		//Small_Weapons
		//Archery
		//Magic
		//Defense

		//Attribute Upgradeable
		//Alchemy
		GetSkill ((int)SkillName.Alchemy).AddModifier (new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Intelligence), 1.0f));
		//Crafting
		GetSkill ((int)SkillName.Crafting).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Intelligence), 1.0f));
		//Forging
		GetSkill ((int)SkillName.Forging).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Intelligence), 1.0f));
		//Speech
		GetSkill ((int)SkillName.Speech).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Charisma), 1.0f));
		//Barter
		GetSkill ((int)SkillName.Barter).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Charisma), 1.0f));
	}

	private void SetupSecondaryAttributeModifier() {
		//Attack_Power
		GetSecondaryAttribute ((int)SecondaryAttributeName.Attack_Power).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Strength), 1.0f));
		//Spell_Power
		GetSecondaryAttribute ((int)SecondaryAttributeName.Spell_Power).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Intelligence), 1.0f));
		//Haste
		GetSecondaryAttribute ((int)SecondaryAttributeName.Haste).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Agility), 0.5f));
		//Critical_Chance
		GetSecondaryAttribute ((int)SecondaryAttributeName.Critical_Chance).AddModifier (new ModifyingAttribute (GetPrimaryAttribute ((int)AttributeName.Agility), 0.5f));
	}

	public void StatUpdate() {
		for (int i = 0; i < vital.Length; i++) {
			vital[i].Update();
		}

		for (int i = 0; i < skill.Length; i++) {
			skill[i].Update();
		}

		for (int i = 0; i < secondaryAttribute.Length; i++) {
			secondaryAttribute[i].Update();
		}
	}
}
