using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumeSettings : MonoBehaviour {

	private Slider volumeSlider;

	public float volume;


	// Use this for initialization
	void Start () {
		volumeSlider = GameObject.Find("volumeSlider").GetComponent<Slider>();
		volumeSlider.value = volume;
	}

	// Update is called once per frame
	void Update () {
		volumeSlider.value = volume;
	}

	public void volumeChange () {
		volume = volumeSlider.value;
	}

	public void volumeSet (float newValue) {
			 float newVol = AudioListener.volume;
			 newVol = newValue;
			 AudioListener.volume = newVol;
	 }
}
