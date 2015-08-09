﻿using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	int score = 0;

	void Start () {
		score = PlayerPrefs.GetInt ("Score");
	}

	void OnGUI() {
		GUI.Label (new Rect (Screen.width / 2 - 40, 50, 80, 30), "GAME OVER");

		GUI.Label (new Rect (Screen.width / 2 - 40, 300, 80, 30), "Fitness: " + score);

		if (GUI.Button (new Rect (Screen.width / 2 - 40, 350, 80, 30), "Retry?")) {
			Application.LoadLevel(0);
		}
	}

}
