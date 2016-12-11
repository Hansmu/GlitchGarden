using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Attacker))] //If we add a Fox, then it has to check if it has an Attacker component.
public class Lizard : MonoBehaviour {

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
			
		animator.SetBool("isAttacking", true);
		attacker.Attack(objectCollidedWith);
	}
}
