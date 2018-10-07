using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponSwing : MonoBehaviour {

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
		if (collider.gameObject.tag == "Enemy") {
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
		if (Input.GetButtonDown("Fire1")&&Time.time > player.GetComponent<playerCombat>().attackTime) {
			this.gameObject.GetComponent<AudioSource>().Play();
			if ((this.gameObject.tag == "playerAttackRight") && (player.GetComponent<playerMovement>().facing == 1)) {
				attack(target, canHit);
			}
			if ((this.gameObject.tag == "playerAttackLeft") && (player.GetComponent<playerMovement>().facing == -1)) {
				attack(target, canHit);
			}
		}
	}

	void attack (GameObject target, bool canHit) {
		if (canHit) {
			target.SendMessage("dealDamage", 10, SendMessageOptions.DontRequireReceiver);
			//want to make this better
		}
	}
}
