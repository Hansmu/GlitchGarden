using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] attackersToSpawn;
	public Score score;

	void Start() {
		score = GameObject.FindObjectOfType<Score>();
	}

	void Update () {
		foreach(GameObject attackerObject in attackersToSpawn) {
			if (isTimeToSpawn(attackerObject)) {
				Spawn(attackerObject);
			}
		}
	}

	bool isTimeToSpawn(GameObject attackerObject) {
		Attacker attacker = attackerObject.GetComponent<Attacker>();
		float meanSpawnDelay = attacker.seenAfterEverySeconds;

		if (score) {
			meanSpawnDelay = attacker.seenAfterEverySeconds / score.GetMultiplier();
		} else {
			meanSpawnDelay = attacker.seenAfterEverySeconds;
		}

		float spawnsPerSecond = 1 / meanSpawnDelay;

		if (Time.deltaTime > meanSpawnDelay) {
			Debug.LogWarning("Spawn rate capped by frame rate.");
		}

		float threshold = spawnsPerSecond * Time.deltaTime / 5; 

		return Random.value < threshold;
	}

	void Spawn(GameObject gameObject) {
		GameObject attacker = Instantiate(gameObject) as GameObject;
		attacker.transform.parent = transform;
		attacker.transform.position = transform.position;
	}
}
