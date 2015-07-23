using UnityEngine;
using System.Collections;

public class Clothing : BuffItem {
	private ArmorSlot slot;

	public Clothing() {
		slot = ArmorSlot.Chest;
	}

	public Clothing (ArmorSlot place) {
		slot = place;
	}

	public ArmorSlot Slot {
		get { return slot; }
		set { slot = value; }
	}
}

public enum ArmorSlot {
	Head,
	Shoulders,
	Chest,
	Waist,
	Legs,
	Hands,
	Feet
}
