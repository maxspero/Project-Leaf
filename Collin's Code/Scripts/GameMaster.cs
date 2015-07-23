using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {
	public GameObject playerCharacter;
	public GameObject gameSettings;
	public Camera mainCamera;
	public float zOffset;
	public float yOffset;

	private GameObject pc;
	private PlayerCharacter pcScript;

	// Use this for initialization
	void Start () {
		pc = Instantiate (playerCharacter, Vector3.zero, Quaternion.identity) as GameObject;
		pc.name = "pc";

		pcScript = pc.GetComponent<PlayerCharacter> ();
		zOffset = -2.5f;
		mainCamera.transform.position = new Vector3(pc.transform.position.x, pc.transform.position.y, pc.transform.position.z + zOffset);
		LoadCharacter ();
	}
	
	public void LoadCharacter() {
		GameObject gs = GameObject.Find ("gameSettings");
		if (gs == null) {
			GameObject gs1 = Instantiate(gameSettings, Vector3.zero, Quaternion.identity) as GameObject;
			gs1.name = "gameSettings";
		}
		GameSettings gsScript = GameObject.Find("gameSettings").GetComponent<GameSettings>();
		gsScript.LoadCharacterData();
	}

	void Update () {
	
	}
}
