using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;

	private AudioSource audioSource;

	void Awake() {
		DontDestroyOnLoad(gameObject);
	}

	void Start() {
		audioSource = GetComponent<AudioSource>();
		audioSource.volume = PlayerPrefsManager.GetMasterVolume();
	}
	
	void OnLevelWasLoaded(int level) { //Called after a level was loaded.
		AudioClip levelMusic = levelMusicChangeArray[level];

		if (levelMusic) {
			audioSource.clip = levelMusic;
			audioSource.loop = true;
			audioSource.Play();
		}
	}

	public void ChangeVolume(float musicVolume) {
		audioSource.volume = musicVolume;
	}
}
