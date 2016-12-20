using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float health = 100f;

	private Score score;

	void Start() {
		score = GameObject.FindObjectOfType<Score>();

		if (score && gameObject.GetComponent<Attacker>()) {
			health *= score.GetMultiplier();
			Debug.Log("Creature health: " + health);
		}
	}

	public void DealDamage(float damage) {
		health -= damage;

		if (health <= 0) {
			DestroyObject();
		}
	}

	public void DestroyObject() {
		Attacker attacker = gameObject.GetComponent<Attacker>();

		if (attacker && score) {
			score.AddToScore(attacker.pointsValue);
		}

		Destroy(gameObject);
	}
}
