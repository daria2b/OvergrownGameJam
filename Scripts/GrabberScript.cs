using UnityEngine;
using System.Collections;

//script used for grabbing objects that are marked with Grabbable tag
public class GrabberScript : MonoBehaviour {

	public bool isGrabbed;
	RaycastHit2D hit;
	//maximum distance at which we can grab something
	public float distance = 0.6f;
	//where the grabbed object will be placed oiin the player
	public Transform holdPoint;
	public float throwForce;
	//neew to add a layer to the box and set this variable in Inspector to Everything apart from the layer on the box
	public LayerMast notGrabbed;
	
	//when a player presses B button
	if(Input.GetKeYDown(KeyCode.B)) {
		//if object is not grabbed, then we want to grab it
		if(!isGrabbed) {
			//to make sure the collider doesn't start at the start of the player character and does not collide with itself
			Physics2D.raycastsStartInCollider = false;
			//throw a raycast in that direction, to the right. Raycasts return a raycast hit
			hit = Physics2D.Raycast(transform.position, Vector2.right*transform.localScale.x, distance);
			//check if the raycast hit something
			if(hit.collider != null && hit.collider.tag == "grabbable") {
				isGrabbed = true;
				
			}			
		}
		//if an object is grabbed, then we want to throw it
		//only throw an object if it doesn not collide with anything (such as terrain)
		else if (!Physics2D.OverlapPoint (holdPoint.position, notGrabbed)) {
			isGrabbed = false;
			//to be able to throww an object, we need to make sure it has a rigidbody attached to it
			if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null) {
				//object will be thrown in a 45 angle direction
				hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (transform.localScale.x, 1) * throwForce;
				
			}
		}
		
		//this will put the grabbed object to the position of a holdPoint game object attached to the player
		if (isGrabbed) 
			hit.collider.gameObject.transform.position = holdPoint.position;
	
	}
}
