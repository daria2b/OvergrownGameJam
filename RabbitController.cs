using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RabbitController : MonoBehaviour {

	public float maxHunger;
	float currentHunger;
	public Slider hungerSlider;

	public static bool full;

	// Use this for initialization
	void Start () {
		full = false;	
		currentHunger = 0;
		hungerSlider.maxValue = maxHunger;
		hungerSlider.value = currentHunger;
	}
	
	// Update is called once per frame
	void Update () {
		//if rabbit's hunger was fulfilled, then the level was cleared!
		if (currentHunger == maxHunger)
			full = true;
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Grabbable") {
			currentHunger += 1f;
			hungerSlider.value = currentHunger;
			Destroy (other.gameObject);
		}
	}
}
