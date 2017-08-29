using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	//time allocated to finish the level
	public float timeLeft;
	//reference to the timer text to update it
	public Text timerText;
	public Text endLevelTextPrefab;
	bool textCreated;

	// Use this for initialization
	void Start () {
		textCreated = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		timeLeft -= Time.deltaTime;
		if (timeLeft < 0)
			timeLeft = 0;
		CountTime ();
	}

	void Update () {
		//if time reaches 0 and the rabbit is still hungry it's gameover
		if (timeLeft <= 0 && !RabbitController.full)
			DisplayEndLevelText ("GAME OVER");
		if (timeLeft > 0 && RabbitController.full)
			DisplayEndLevelText ("Level cleared!");
		if (Input.GetKeyDown(KeyCode.Escape) {
			SceneManager.LoadScene(0);
		}
	}

	void CountTime () {
		timerText.text = "Time left: " + Mathf.RoundToInt (timeLeft);
	}

	void DisplayEndLevelText (string displayText) {
		if (!textCreated) {
			//find canvas
			GameObject canvas = GameObject.Find ("MainCanvas");
			//clone the text prefab
			Text endLevelText = Instantiate (endLevelTextPrefab, new Vector3 (Screen.width * 0.5f, Screen.height * 0.7f, 0), Quaternion.identity);
			endLevelText.transform.SetParent (canvas.transform);
			endLevelText.text = displayText;
			textCreated = true;
		}
	}
}
