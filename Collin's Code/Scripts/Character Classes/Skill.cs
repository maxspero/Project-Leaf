public class Skill : ModifiedStat {
	private bool known;

	public Skill() {
		known = true;
	}

	public bool Known {
		get{ return known;}
		set{ known = value; }
	}
}

public enum SkillName {
	One_H_Wep,
	Two_H_Wep,
	Small_Wep,
	Archery,
	Magic,
	Defense,
	Alchemy,
	Crafting,
	Forging,
	Speech,
	Barter
}