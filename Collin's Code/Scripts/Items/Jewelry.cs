using UnityEngine;
using System.Collections;

public class Jewelry : BuffItem {
	private JewelrySlot slot;

	public Jewelry() {
		slot = JewelrySlot.Trinket;
	}

	public Jewelry(JewelrySlot socket) {
		slot = socket;
	}

	public JewelrySlot Slot {
		get { return slot; }
		set { slot = value; }
	}
}

public enum JewelrySlot {
	EarRings,
	Necklaces,
	Rings,
	Trinket
}
