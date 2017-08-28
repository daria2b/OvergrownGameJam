using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RabbitController : MonoBehaviour {

	public float maxHunger;
	float currentHunger;
	public Slider hungerSlider;

	public static bool full;
	public GameObject crumblesFX;

	Animator myAnim;

	// Use this for initialization
	void Start () {
		myAnim = GetComponent<Animator> ();
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
			myAnim.SetTrigger ("foodArrived");
			hungerSlider.value = currentHunger;
			Destroy (other.gameObject);
			Invoke ("LaunchCrumblesFX", 0.3f);
		}
	}

	void LaunchCrumblesFX () {
		Instantiate (crumblesFX, transform.Find("head").transform.position, transform.rotation);
	}
}
