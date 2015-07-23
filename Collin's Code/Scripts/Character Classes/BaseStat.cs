using UnityEngine;
using System.Collections;

public class BaseStat {
	private int baseValue;
	private int buffValue;
	private string name;

	public BaseStat() {
		baseValue = 0;
		buffValue = 0;
		name = "";
	}

	public int BaseValue {
		get { return baseValue; }
		set { baseValue = value; }
	}

	public int BuffValue {
		get { return buffValue; }
		set { buffValue = value; } 
	}

	public void LevelUp() {
		baseValue++;
	}

	public int AdjustedBaseValue {
		get { return baseValue + buffValue; }
	}
	
	public string Name {
		get { return name; }
		set{ name = value; }
	}
}
