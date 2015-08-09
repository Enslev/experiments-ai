using UnityEngine;
using System.Collections;

public class HUDScript : MonoBehaviour {

	private float bonus = 0;
	private float playerScore = 0;
	public Transform player;

	// Update is called once per frame
	void Update () {
		playerScore = player.position.x + bonus;
	}

	public void IncreaseScore(int amount) {
		bonus += amount;
	}

	void OnDisable() {
		PlayerPrefs.SetInt ("Score", (int)playerScore);
	}

	void OnGUI() {
		GUI.Label (new Rect (10, 10, 100, 30), "Fitness: " + (int)(playerScore));
	}
}
