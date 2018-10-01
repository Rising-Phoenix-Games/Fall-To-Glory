using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFireball : MonoBehaviour {

	Animator fireballAnim;
	public float speed;
	public Vector2 direction;
	public GameObject target;
	public float maxRange;

	// Use this for initialization
	void Start () {
		fireballAnim	= GetComponent<Animator>();
		target = GameObject.FindWithTag("Player");
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
			fireballAnim.SetTrigger("Fireball_collision");
			Destroy(this.gameObject);
			if (collision.gameObject.CompareTag("Player")) {
				target.GetComponent<playerCombat>().TakeDamage(5);
			}
		}
	}
}
