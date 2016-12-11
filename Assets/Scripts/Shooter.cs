using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile, gun;

	private GameObject projectileParent;
	private Animator animator;
	private Spawner laneSpawner;

	void Start() {
		animator = GameObject.FindObjectOfType<Animator>();
		projectileParent = GameObject.Find("Projectiles");

		if (!projectileParent) {
			projectileParent = new GameObject("Projectiles");
		}

		SetLaneSpawner();
	}

	void Update() {
		if (IsAttackerAheadInLane()) {
			animator.SetBool("isAttacking", true);
		} else {
			animator.SetBool("isAttacking", false);
		}
	}

	void SetLaneSpawner() {
		Spawner[] spawners = GameObject.FindObjectsOfType<Spawner>();

		foreach(Spawner spawner in spawners) {
			if (spawner.transform.position.y == transform.position.y) {
				laneSpawner = spawner;
				return;
			}
		}

		Debug.LogError(name + " can't find spawner in lane.");
	}

	bool IsAttackerAheadInLane() {
		bool noAttackersInLane = false;
		bool attackersAheadOfShooter = true;
		bool attackersInLaneButBehind = false;

		if (laneSpawner.transform.childCount <= 0) {
			return noAttackersInLane;
		}

		foreach(Transform attacker in laneSpawner.transform) {
			float attackerLocationX = attacker.transform.position.x;
			float shooterLocationX = transform.position.x;

			if (attackerLocationX >= shooterLocationX) {
				return attackersAheadOfShooter;
			}
		}

		return attackersInLaneButBehind;
	}

	private void Fire() {
		GameObject newProjectile = Instantiate(projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
}
