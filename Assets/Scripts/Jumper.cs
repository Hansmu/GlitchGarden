using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Attacker))] //If we add a Jumper, then it has to check if it has an Attacker component.
public class Jumper : MonoBehaviour {

	private Animator animator;
	private Attacker attacker;

	void Start () {
		animator = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
	}

	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collidedWith) {

		GameObject objectCollidedWith = collidedWith.gameObject;
		if (!objectCollidedWith.GetComponent<Defenders>()) {
			return;
		}

		if(objectCollidedWith.GetComponent<Stone>()) { //Detects on scripts attached to the component.
			animator.SetTrigger("jumpTrigger");
		} else if(objectCollidedWith.GetComponent<Blocker>()) {
			animator.SetTrigger("jumpTrigger");
		} else {
			animator.SetBool("isAttacking", true);
			attacker.Attack(objectCollidedWith);
		}
	}
}
