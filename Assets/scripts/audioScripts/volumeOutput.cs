using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumeOutput : MonoBehaviour {

	private Slider volumeSlider;

	// Use this for initialization
	void Start () {
		volumeSlider = GameObject.Find("volumeSlider").GetComponent<Slider>();
	}

	// Update is called once per frame
	void Update () {
		this.gameObject.GetComponent<AudioSource>().volume = volumeSlider.value;
	}
}
