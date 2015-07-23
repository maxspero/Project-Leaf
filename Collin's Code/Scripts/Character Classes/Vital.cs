public class Vital : ModifiedStat {
	private int curValue;

	public Vital() {
		curValue = 0;
	}

	public int CurValue {
		get{
			if(curValue > AdjustedBaseValue)
				curValue = AdjustedBaseValue;

			return curValue;
		}
		set{ curValue = value; }
	}

	public void Set() {
		curValue = AdjustedBaseValue;
		BaseValue = AdjustedBaseValue;
	}
}

public enum  VitalName {
	Health,
	Energy,
	Mana
}
