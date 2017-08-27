using UnityEngine;
using System.Collections;

//script used for grabbing objects that are marked with Grabbable tag
public class GrabberScript : MonoBehaviour {

	public bool isGrabbed;
	GameObject grabbed;
	//maximum distance at which we can grab something
	public float distance = 5f;
	//where the grabbed object will be placed oiin the player
	public Transform holdPoint;
	public float throwForce;


	void OnTriggerStay2D (Collider2D other) {
		if (other.gameObject.tag == "Grabbable") {
			if (Input.GetKeyDown (KeyCode.E) || Input.GetMouseButtonDown (0)) {
				//if object is not grabbed, then we want to grab it
				if (!isGrabbed) {
					grabbed = other.gameObject;
					isGrabbed = true;
				}			
			}
		}
	}

	void Update () {
		//this will put the grabbed object to the position of a holdPoint game object attached to the player
		if (isGrabbed && grabbed != null) {
			grabbed.transform.position = holdPoint.position;
				
			if (Input.GetKeyDown (KeyCode.R) || Input.GetMouseButtonDown (1)) {
				isGrabbed = false;
				//to be able to throww an object, we need to make sure it has a rigidbody attached to it
				if (grabbed.GetComponent<Rigidbody2D> () != null) {
					//object will be thrown at 45 degrees angle
					grabbed.GetComponent<Rigidbody2D> ().velocity = new Vector2 (transform.localScale.x, 1) * throwForce;
				}
			}
		}
	}
		
}
