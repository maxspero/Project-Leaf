using UnityEngine;
using System.Collections;

public class Armor : Clothing {
	private int armor;

	public Armor() {
		armor = 0;
	}

	public Armor(int al) {
		armor = al;
	}

	public int ArmorLevel {
		get { return armor; }
		set { armor = value; }
	}
}
