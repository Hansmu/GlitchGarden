﻿using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevelAfter;

	void Start() {
		if (autoLoadNextLevelAfter <= 0) {		
			Debug.Log("Auto-load disabled. Use a positive number, it's in seconds.");
		} else {
			Invoke("LoadNextLevel", autoLoadNextLevelAfter);
		}
	}

	public void LoadLevel(string name) {
		Application.LoadLevel(name);
	}

	public void LoadLoseLevel() {
		LoadLevel("03b_Lose");
	}

	public void QuitRequest() {
		Application.Quit();
	}

	public void LoadNextLevel() { //You have to consider the build settings with this, they have to be in the right order.
		Application.LoadLevel(Application.loadedLevel + 1);
	}
}
