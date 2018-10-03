using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class classAbility : MonoBehaviour {

	public GameObject target;
	GameObject player;
	bool canHit;
	public Collider2D enemyThing;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
		canHit = false;
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.tag == "enemyfireball") {
			enemyThing = collider;
			target = collider.gameObject;
		}
	}

	// Update is called once per frame
	void Update () {
		if (this.gameObject.GetComponent<BoxCollider2D>().IsTouching(enemyThing)) {
			canHit = true;
		}
		else {
			target = null;
			canHit = false;
		}
		if (Input.GetButtonDown("Fire2")&&Time.time > player.GetComponent<playerCombat>().attackTime) {
			if ((this.gameObject.tag == "playerBlockRight") && (player.GetComponent<playerMovement>().facing == 1)) {
				blocked(target, canHit);
			}
			if ((this.gameObject.tag == "playerBlockLeft") && (player.GetComponent<playerMovement>().facing == -1)) {
				blocked(target, canHit);
			}
		}
	}

	void blocked (GameObject target, bool canHit) {
		if (canHit) {
			if (target.gameObject.tag == "enemyfireball") {
				Destroy(target);
			}
		}
	}
}
