 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerCombat : MonoBehaviour {

	public int playerMaxHealth = 100;
	public int playerHealth;
	public Slider slider;
	public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
 	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.
	public bool isDead;                                                // Whether the player is dead.
 	bool damaged;
	public Image damageImage;                                   // True when the player gets damaged.
	public Animator playerKnightMovementAnim;
	playerMovement playerMovement;
	public bool godMode = false;
	public float attackTime;
	public float attackDuration;
	public float abilityTime;
	public float abilityDuration;


	// Use this for initialization
	void Start () {
		playerKnightMovementAnim = GetComponent<Animator>();
		playerHealth = playerMaxHealth;
		playerMovement = GetComponent <playerMovement> ();
		//godMode = false;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Enemy"))
		{
				TakeDamage(10);
		}
	}

	// Update is called once per frame
	void Update () {
		if(damaged) {
			 //damageImage.color = flashColour; // ... set the colour of the damageImage to the flash colour.
		}
		else {
			 //	damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime); // ... transition the colour back to clear.
		}
		damaged = false; // Reset the damaged flag.

		if (Input.GetButtonDown("Fire1")&&Time.time > attackTime) {
			attackTime = Time.time + attackDuration;
			playerKnightMovementAnim.SetInteger("facing", playerMovement.facing);
			playerKnightMovementAnim.SetTrigger("basic attack");
		}

		if (Input.GetButton("Fire2")) {
			playerKnightMovementAnim.SetInteger("facing", playerMovement.facing);
			playerKnightMovementAnim.SetBool("block", true);
		}
		else {
			playerKnightMovementAnim.SetBool("block", false);
		}

		if (godMode) {
			playerHealth = 100;
		}
		slider.value = playerHealth;
	}


	public void TakeDamage (int amount){
		int damageamount = amount;
		damaged = true;
	  playerHealth -= damageamount;
	 	if(playerHealth <= 0 && !isDead)
     {
   			Death ();
     }
		 else {
		 }

	}

	void Death (){
		// Set the death flag so this function won't be called again.
	  isDead = true;

	  // Tell the animator that the player is dead.
	  //playerKnightMovementAnim.SetTrigger ("Die");

	  // Turn off the movement script.
	  playerMovement.enabled = false;
	}
}
