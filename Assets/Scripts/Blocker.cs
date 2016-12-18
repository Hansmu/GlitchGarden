using UnityEngine;
using System.Collections;

public class Blocker : MonoBehaviour {

	private Animator animator;
	private Health attackerHealth;

	void Start () {
		animator = GetComponent<Animator>();
	}

	void OnTriggerEnter2D(Collider2D collider) {
		Attacker attacker = collider.gameObject.GetComponent<Attacker>();

		if (attacker) {
			attackerHealth = collider.gameObject.GetComponent<Health>();	
		}
	}

	void OnTriggerStay2D(Collider2D collider) {
		Attacker attacker = collider.gameObject.GetComponent<Attacker>();
		Jumper jumper = collider.gameObject.GetComponent<Jumper>();

		if (attacker && !jumper) {
			animator.SetBool("isAttacking", true);
		}
	}

	void OnTriggerExit2D(Collider2D collider) {
		Debug.Log("Exited!");

		if (animator.GetBool("isAttacking")) {
			animator.SetBool("isAttacking", false);
		}
	}

	public void DealDamageToAttacker(float damage) {
		if(attackerHealth) {
			attackerHealth.DealDamage(damage);
		} else {
			animator.SetBool("isAttacking", false);
		}
	}
}
