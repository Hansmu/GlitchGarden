using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Attacker))] //If we add a Fox, then it has to check if it has an Attacker component.
public class Lizard : MonoBehaviour {

	private Animator animator;
	private Attacker attacker;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D collidedWith) {
		Debug.Log("Fox collided with " + collidedWith);

		GameObject objectCollidedWith = collidedWith.gameObject;
		if (!objectCollidedWith.GetComponent<Defenders>()) {
			return;
		}
			
		animator.SetBool("isAttacking", true);
		attacker.Attack(objectCollidedWith);
	}
}
