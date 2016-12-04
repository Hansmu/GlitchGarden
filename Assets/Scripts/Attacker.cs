using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

	public float walkSpeed;
	private GameObject currentTarget;

	// Use this for initialization
	void Start () {
		Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D>();
		myRigidbody.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
	}

	void OnTriggerEnter2D() {
		Debug.Log(name + " trigger enter.");
	}

	public void SetSpeed(float speed) {
		walkSpeed = speed;
	}

	public void HitTarget(float damage) { //Called from the animator at time of attack
		Debug.Log(name + " caused damage " + damage);
	}

	public void Attack(GameObject targetToAttack) { //Puts attacker into attack mode
		currentTarget = targetToAttack;
	}
}
