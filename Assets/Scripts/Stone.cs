using UnityEngine;
using System.Collections;

public class Stone : MonoBehaviour {

	private Animator animator;

	void Start () {
		animator = GetComponent<Animator>();
	}

	void OnTriggerStay2D(Collider2D collider) {
		Debug.Log("On trigger.");
		Attacker attacker = collider.gameObject.GetComponent<Attacker>();

		if (attacker) {
			Debug.Log("Is attacker!");
			animator.SetTrigger("underAttackTrigger");
		}
	}
}
