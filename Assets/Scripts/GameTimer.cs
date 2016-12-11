using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {

	public float levelSeconds = 5;

	private Slider slider;
	private AudioSource audioSource;
	private LevelManager levelManager;
	private bool hasCalledWon = false;
	private GameObject winLabel;

	void Start () {
		slider = GetComponent<Slider>();
		audioSource = GetComponent<AudioSource>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();

		slider.value = 1;

		FindWinLabel();
		winLabel.SetActive(false);
	}

	void Update () {
		float progress = 1 - Time.timeSinceLevelLoad / levelSeconds;

		if (progress >= 0) {
			slider.value = progress;
		} else if (!hasCalledWon) {
			audioSource.Play();
			winLabel.SetActive(true);
			Invoke("LoadNextLevel", audioSource.clip.length);
			hasCalledWon = true;
		}
	}

	private void FindWinLabel() {
		winLabel = GameObject.Find("You Win");

		if (!winLabel) {
			Debug.LogWarning("Please create You Win object.");
		}
	}

	private void LoadNextLevel() {
		levelManager.LoadNextLevel();
	}
}
