using UnityEngine;
using System.Collections;

public class ScoreCollider : MonoBehaviour {

	private LevelManager levelManager;

	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	void OnTriggerEnter2D() {
		levelManager.LoadLevel("04_Score");	
	}
}
