using UnityEngine;
using System.Collections;

public class Weapon : BuffItem {
	private int maxDamage;
	private float damageVariance;
	private float maxRange;
	private DamageType dmgType;

	public Weapon() {
		maxDamage = 0;
		damageVariance = 0;
		maxRange = 0;
		dmgType = DamageType.Normal;
	}

	public Weapon(int mDmg, float dmgVar, float mRan, DamageType dt) {
		maxDamage = mDmg;
		damageVariance = dmgVar;
		maxRange = mRan;
		dmgType = dt;
	}

	public int MaxDamage {
		get { return maxDamage; }
		set { maxDamage = value; }
	}

	public float DamageVariance {
		get { return damageVariance; }
		set { damageVariance = value; }
	}

	public float MaxRange {
		get { return maxRange; }
		set { maxRange = value; }
	}

	public DamageType TypeOfDamage{
		get { return dmgType; }
		set { dmgType = value; }
	}
}

public enum DamageType {
	Normal,
	Earth,
	Fire,
	Ice,
	Lightning,
	Holy,
	Shadow,
	Legend

}
