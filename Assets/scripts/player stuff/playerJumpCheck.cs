using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerJumpCheck : MonoBehaviour {

	GameObject player;
	public bool canJump = true;
	public bool canDoubleJump = true;
	Rigidbody2D playerRB;
	public float playerJumpHeight;
	public Collider2D groundThing;



	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
		playerRB = player.GetComponent<Rigidbody2D>();
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.CompareTag("Platform")) {
			canJump = true;
			canDoubleJump = true;
			groundThing = collider;
		}
	}

	void OnTriggerExit2D(Collider2D collision)
	{
	    if (collision.gameObject.CompareTag("Platform"))
	    {
				canDoubleJump = true;
	    }
	}

	// Update is called once per frame
	void Update () {
		if (this.gameObject.GetComponent<BoxCollider2D>().IsTouching(groundThing)) {
			canJump = true;
			canDoubleJump = true;
		}
		if ((Input.GetButtonDown("Jump")) && (canJump)) { //jumping code
			player.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
			playerRB.AddForce(new Vector2(0, playerJumpHeight), ForceMode2D.Impulse);
			canJump=false;
		}
		if ((Input.GetButtonDown("Jump")) && ((canDoubleJump) && !(canJump))) {//double jumping code
			player.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
			playerRB.AddForce(new Vector2(0, playerJumpHeight), ForceMode2D.Impulse);
			canDoubleJump=false;
		}
	}
}
