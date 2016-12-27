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
			DestroyAllTaggedObjects();
		}
	}

	private void DestroyAllTaggedObjects() {
		GameObject[] taggedObjectArray = GameObject.FindGameObjectsWithTag("destroyOnWin");

		foreach(GameObject taggedObject in taggedObjectArray) {
			Destroy(taggedObject);
		}
	}

	private void FindWinLabel() {
		winLabel = GameObject.Find("You Win");

		if (!winLabel) {
			Debug.LogWarning("Please create You Win object.");
		} else {
			winLabel.SetActive(false);
		}
	}

	private void LoadNextLevel() {
		levelManager.LoadNextLevel();
	}
}
