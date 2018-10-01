using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

	Rigidbody2D playerRB;
	public Animator playerKnightMovementAnim;

	// Use this for initialization
	void Start () {
		playerKnightMovementAnim = GetComponent<Animator>();
		playerRB = GetComponent<Rigidbody2D>();
	}

	public float playerMovementSpeed = 7f;
	public float playerJumpHeight = 10;
	public int dashSpeed = 15;
	public int facing;
	public bool moving = false;
	bool canJump = true;
	bool canDoubleJump = true;


	void OnCollisionEnter2D(Collision2D collision)
	{
	    if (collision.gameObject.CompareTag("Platform"))
	    {
	        canJump=true;
					canDoubleJump=true;
	    }
	}

	void OnCollisionExit2D(Collision2D collision)
	{
	    if (collision.gameObject.CompareTag("Platform"))
	    {
				canDoubleJump=true;
	    }
	}

	// Update is called once per frame
	void Update () {

		if ((Input.GetButtonDown("Jump")) && (canJump)) { //jumping code
			GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
			playerRB.AddForce(new Vector2(0, playerJumpHeight), ForceMode2D.Impulse);
			canJump=false;
		}
		if ((Input.GetButtonDown("Jump")) && ((canDoubleJump) && !(canJump))) {//double jumping code
			GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
			playerRB.AddForce(new Vector2(0, playerJumpHeight), ForceMode2D.Impulse);
			canDoubleJump=false;
		}
		if (Input.GetKey(KeyCode.S)) { //nothing... yet
				//transform.Translate(Vector2.down * playerMovementSpeed * Time.deltaTime);
				moving = false;
		}
		if ((Input.GetAxis("Horizontal")) < 0) { //moving left
				transform.Translate (Vector2.left * playerMovementSpeed * Time.deltaTime);
				facing = -1;//-1 is used here to symbolize left as a integer
				moving = true;
		}
		if (Input.GetAxis("Horizontal") > 0) { //moving right
				transform.Translate(Vector2.right * playerMovementSpeed * Time.deltaTime);
				facing = 1; //1 is used here to sybolize right as a integer
				moving = true;
		}
		if (Input.GetButtonDown("Dash")) { //dash movement thing
			if (facing == 1) {
				playerRB.MovePosition(new Vector2( playerRB.position.x + dashSpeed, 0));
			}
			else if (facing == -1) {
				playerRB.MovePosition(new Vector2( playerRB.position.x - dashSpeed, 0));
			}
		}
		if (((Input.GetAxis("Horizontal")) == 0)) { //no movement (just for setting moving to false)
			moving = false;
		}
		playerKnightMovementAnim.SetInteger("facing", facing);
		playerKnightMovementAnim.SetBool("moving", moving);
	}
}
