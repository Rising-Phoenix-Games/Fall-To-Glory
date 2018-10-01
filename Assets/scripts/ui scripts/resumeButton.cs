using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resumeButton : MonoBehaviour {

	public bool paused = false;
	GameObject[] pauseThings;
	GameObject player;
	playerMovement playerMovement;

	void Start()
	{
		player = GameObject.FindWithTag ("Player");
		pauseThings = GameObject.FindGameObjectsWithTag("pauseMenu");
		playerMovement = player.GetComponent<playerMovement>();
	}

	public void isPaused() {
		paused = false;
		if(Time.timeScale == 0f)
		{
			Time.timeScale = 1f;
			foreach (GameObject pauseThing in pauseThings) {
				pauseThing.SetActive(false);
			}
			if (player.GetComponent<playerCombat>().isDead) {
				playerMovement.enabled = false;
				player.GetComponent<playerCombat>().enabled = false;
			} else {
				playerMovement.enabled = true;
				player.GetComponent<playerCombat>().enabled = true;
			}
		}
	}
}
