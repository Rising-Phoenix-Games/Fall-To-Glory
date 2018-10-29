using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseMenu : MonoBehaviour {

	public bool paused = false;
	GameObject[] pauseThings;
	GameObject resumeButton;
	GameObject player;
	playerMovement playerMovement;

	void Start()
	{
		Time.timeScale = 1f;
		player = GameObject.FindWithTag ("Player");
		resumeButton = GameObject.Find ("resumeButton");
		playerMovement = player.GetComponent<playerMovement>();
//	GameObject.Find("Main Camera").AudioListener.volume = GameObject.Find("volumeSlider").GetComponent<Slider>().value;
		pauseThings = GameObject.FindGameObjectsWithTag("pauseMenu");
		foreach (GameObject pauseThing in pauseThings) {
			pauseThing.SetActive(false);
		}
	}

	void Update()
	{
		if (Input.GetButtonDown ("Cancel")) {
			resumeButton.GetComponent<resumeButton>().paused = togglePause ();
		}

		paused = resumeButton.GetComponent<resumeButton> ().paused;
	}


	bool togglePause()
	{
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
			return(false);
		}
		else
		{
			foreach (GameObject pauseThing in pauseThings) {
				pauseThing.SetActive(true);
			}
			playerMovement.enabled = false;
			player.GetComponent<playerCombat>().enabled = false;
			Time.timeScale = 0f;
			return(true);
		}
	}
}
