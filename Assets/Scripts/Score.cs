using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	private static long currentScore = 0;
	private float multiplier = 1f;

	private Text scoreText;

	void Start () {
		scoreText = GetComponent<Text>();
		scoreText.text = currentScore.ToString();
	}

	public void AddToScore(int amountToAdd) {
		currentScore += amountToAdd;
		scoreText.text = currentScore.ToString();

		multiplier = 1.0f + (currentScore * 1.0f) / 2500;
	}

	public float GetMultiplier() {
		return multiplier;
	}
}
