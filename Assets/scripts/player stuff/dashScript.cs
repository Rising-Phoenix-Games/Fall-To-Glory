using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashScript : MonoBehaviour {

	public DashState dashState;
	public float dashTimer;
	public float maxDash = 20f;
	public Rigidbody2D playerRB;

	public Vector2 savedVelocity;

	void Start() {
		playerRB = GetComponent<Rigidbody2D>();
	}

	void Update () {
		switch (dashState) {
			case DashState.Ready:
				if(Input.GetButtonDown("Dash")) {
					savedVelocity = playerRB.velocity;
					Debug.Log(playerRB.velocity.x);
					playerRB.velocity =  new Vector2(playerRB.velocity.x * 3f, playerRB.velocity.y);
					dashState = DashState.Dashing;
				}
			break;
			case DashState.Dashing:
				dashTimer += Time.deltaTime * 3;
				if(dashTimer >= maxDash)	{
					dashTimer = maxDash;
					playerRB.velocity = savedVelocity;
					dashState = DashState.Cooldown;
				}
			break;
			case DashState.Cooldown:
				dashTimer -= Time.deltaTime*2;
				if(dashTimer <= 0) {
					dashTimer = 0;
					dashState = DashState.Ready;
				}
			break;
		}
	}
}

public enum DashState
{
		Ready,
		Dashing,
		Cooldown
}
