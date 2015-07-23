using UnityEngine;
using System.Collections;

public class Consumable : BuffItem {
	private Vital[] vitals;
	private int[] amount;

	private float buffTime;

	public Consumable() {
		Reset ();
	}

	public Consumable(Vital[] v, int[] amt, float bufft) {
		vitals = v;
		amt = amount;
		bufft = buffTime;
	}

	public void Reset() {
		buffTime = 0;
		for (int i = 0; i < vitals.Length; i++) {
			vitals[i] = new Vital();
			amount[i] = 0;
		}
	}

	public int VitalCount() {
		return vitals.Length;
	}

	public int HealAtIndex(int index){
		if (index < amount.Length && index > -1)
			return amount [index];
		else
			return 0;
	}

	public Vital VitalAtIndex(int index){
		if(index < vitals.Length && index > -1)
			return vitals [index];
		else
			return new Vital();
	}

	public float BuffTime {
		get { return buffTime; }
		set { buffTime = Value; }
	}

	public void SetVitalAt(int index, Vital vital) {
		if(index < vitals.Length && index > -1) 
			vitals[index] = vital;
	}

	public void SetHealAt(int index, int heal) {
		if (index < amount.Length && index > -1)
			amount [index] = heal;
	}

	public void SetVitalAndHealAt(int index, Vital vital, int heal){
		SetVitalAt (index, vital);
		SetHealAt (index, heal);
	}
}
