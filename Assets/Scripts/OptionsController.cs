using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider;
	public LevelManager levelManager;

	private MusicManager musicManager;

	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager>();

		volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
	}

	void Update () {
		musicManager.ChangeVolume(volumeSlider.value);
	}

	public void SaveAndExit() {
		PlayerPrefsManager.SetMasterVolume(volumeSlider.value);

		Debug.Log(levelManager);
		levelManager.LoadLevel("01a_Start");
	}

	public void SetDefaults() {
		volumeSlider.value = 0.8f;
	}
}
