using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider;
	public LevelManager levelManager;

	private MusicManager musicManager;

	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager>();

		if (volumeSlider) {
			volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
		}
	}

	void Update () {
		if (volumeSlider) {
			musicManager.ChangeVolume(volumeSlider.value);
		}
	}

	public void SaveAndExit() {
		if (volumeSlider) {
			PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
		}

		levelManager.LoadLevel("01a_Start");
	}

	public void SetDefaults() {
		volumeSlider.value = 0.8f;
	}
}
