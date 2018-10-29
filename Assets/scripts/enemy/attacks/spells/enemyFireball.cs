using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFireball : MonoBehaviour {

	Animator fireballAnim;
	public float speed;
	public Vector2 direction;
	public GameObject target;
	public float maxRange;
	public int damage;

	// Use this for initialization
	void Start () {
		fireballAnim	= GetComponent<Animator>();
		target = GameObject.FindWithTag("Player");
		damage = 5;
	}


	// Update is called once per frame
	void Update () {
		if (direction != Vector2.zero) {
		transform.position = (Vector2)transform.position + direction * speed * Time.deltaTime;
		}
		else {
		Debug.LogError("Fireball lacks a direction!");
		DestroyImmediate(this);
		}
		if (Vector2.Distance(transform.position, target.transform.position)>maxRange) {
				Destroy(this.gameObject);
		}
	}

	void OnCollisionStay2D(Collision2D collision)	{
		if (collision.gameObject.CompareTag("Platform")||collision.gameObject.CompareTag("Player")) {
			if (collision.gameObject.CompareTag("Player")) {
				target.GetComponent<playerCombat>().TakeDamage(damage);
			}
			fireballAnim.SetTrigger("Fireball_collision");
			Destroy(this.gameObject);
		}
	}
	void OnTriggerEnter2D (Collider2D collision) {
		if ((collision.gameObject.CompareTag("playerBlockRight") || collision.gameObject.CompareTag("playerBlockLeft"))&&Input.GetButton("Fire2")) {
			collision.gameObject.GetComponent<classAbility>().blockThing(damage, this.gameObject);
			fireballAnim.SetTrigger("Fireball_collision");
			Destroy(this.gameObject);
		}
	}
}
