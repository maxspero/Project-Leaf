using System.Collections.Generic;
using UnityEditor;
using System.Collections;
using UnityEngine;

public class ModifiedStat : BaseStat {
	private List<ModifyingAttribute> mods;
	private int modValue;
	public ModifiedStat() {
		mods = new List<ModifyingAttribute> ();
		modValue = 0;
	}
	public void AddModifier(ModifyingAttribute mod) {
		mods.Add (mod);
	}

	private void CalculateModValue() {
		modValue = 0;

		if (mods.Count > 0)
			foreach (ModifyingAttribute att in mods)
				modValue += (int)(att.attribute.AdjustedBaseValue * att.ratio); 
	}

	public new int AdjustedBaseValue {
		get { return BaseValue + BuffValue + modValue; }
	}

	public void Update() {
		CalculateModValue ();
	}
	
}

public struct ModifyingAttribute {
	public Attribute attribute;
	public float ratio;

	public ModifyingAttribute(Attribute att, float rat) {
		attribute = att;
		ratio = rat;
	}
}