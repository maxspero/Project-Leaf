using UnityEngine;
using System.Collections;

public class Item {
	private string name;
	private int val;
	private RarityType rarity;
	private int maxDurability;
	private int curDurability;

	public Item() {
		name = "Need Name";
		val = 0;
		rarity = RarityType.Ordinary;
		maxDurability = 1;
		curDurability = maxDurability;
	}

	public Item(string nam, int value, RarityType rare, int maxDur, int curDur) {
		name = nam;
		val = value;
		rarity = rare;
		maxDurability = maxDur;
		curDurability = curDur;
	}

	public string Name {
		get { return name; }
		set { name = value; }
	}

	public int Value {
		get { return val; }
		set { val = value; }
	}

	public RarityType Rarity {
		get { return rarity; }
		set { rarity = value; }
	}

	public int MaxDurability {
		get { return maxDurability; }
		set { maxDurability = value; }
	}

	public int CurDurability {
		get { return curDurability; }
		set { curDurability = value; }
	}
}

public enum RarityType {
	Ordinary,
	Magical,
	Unique,
	Legendary
}
