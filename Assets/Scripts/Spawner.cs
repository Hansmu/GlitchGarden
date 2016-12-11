using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] attackersToSpawn;
	
	// Update is called once per frame
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
		float spawnsPerSecond = 1 / meanSpawnDelay;

		if (Time.deltaTime > meanSpawnDelay) {
			Debug.LogWarning("Spawn rate capped by frame rate.");
		}

		float threshold = spawnsPerSecond * Time.deltaTime / 5; 

		if(Random.value < threshold) {
			return true;
		}
		return false;
	}

	void Spawn(GameObject gameObject) {
		GameObject attacker = Instantiate(gameObject) as GameObject;
		attacker.transform.parent = transform;
		attacker.transform.position = transform.position;
	}
}
