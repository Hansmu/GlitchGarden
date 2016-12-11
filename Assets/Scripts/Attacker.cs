using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

	public float walkSpeed;
	public float seenAfterEverySeconds;

	private GameObject currentTarget;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D>();
		myRigidbody.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(animator);
		transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
		if (!currentTarget) {
			animator.SetBool("isAttacking", false);
		}
	}

	void OnTriggerEnter2D() {
		Debug.Log(name + " trigger enter.");
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
