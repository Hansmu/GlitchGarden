using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

	public float walkSpeed;
	public float seenAfterEverySeconds;
	public int pointsValue;

	private GameObject currentTarget;
	private Animator animator;

	void Start () {
		animator = GetComponent<Animator>();
	}

	void Update () {
		transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
		if (!currentTarget) {
			animator.SetBool("isAttacking", false);
		}
	}

	public void SetSpeed(float speed) {
		walkSpeed = speed;
	}

	public void HitTarget(float damage) { //Called from the animator at time of attack
		if (currentTarget) {
			Health health = currentTarget.GetComponent<Health>();

			if (health) {
				health.DealDamage(damage);	
			}
		}
	}

	public void Attack(GameObject targetToAttack) { //Puts attacker into attack mode
		currentTarget = targetToAttack;
	}
}
