using UnityEngine;
using System.Collections;

//script used for grabbing objects that are marked with Grabbable tag
public class GrabberScript : MonoBehaviour {

	//if something was grabbed
	public bool isGrabbed;
	//maximum distance at which we can grab something
	//public float distance = 5f;
	//where the grabbed object will be placed on the player
	public Transform holdPoint;
	//variable to cast a grab circle
	public float throwForce;
	float grabCheckRadius = 2f;
	public LayerMask grabLayer;
	public Transform grabCheckPosition;
	Collider2D grabbable;
	Collider2D grabbed;

	void Update () {
		//check if player is close enough to a grabbable object and store the collider it intersected in a temporary variable
		grabbable = Physics2D.OverlapCircle(grabCheckPosition.position, grabCheckRadius, grabLayer);
		if (grabbable != null) {
			//if player pressed grab button while intersecting a grabbable collider
			if (Input.GetKeyDown (KeyCode.E) || Input.GetMouseButtonDown (0)) {
				//then if grabbed an object
				isGrabbed = true;
				//store the grabbed object collider in a longterm use variable
				grabbed = grabbable;
			}
		}
		//if player has grabbed an object
		if (isGrabbed) {
			//keep the object above the player
			grabbed.transform.position = holdPoint.position;
			//if while holding an object the player clicks a throw button	
			if (Input.GetKeyDown (KeyCode.R) || Input.GetMouseButtonDown (1)) {
				//then no objects are currently grabbed
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
