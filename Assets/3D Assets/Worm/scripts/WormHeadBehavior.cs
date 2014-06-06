using UnityEngine;
using System.Collections;

public class WormHeadBehavior : MonoBehaviour
{

	public static float distanceTraveled;
	
	private bool touchingSurface;
	
	public Vector2 jumpVelocity;
	public Transform center;
	
	void Update () {
		if (Input.GetAxis ("Horizontal") > 0) { // Right
			rigidbody2D.AddForce (jumpVelocity * Time.deltaTime * Mathf.Pow(2f, (center.localPosition.y - transform.localPosition.y - 2f) ) );

			rigidbody2D.fixedAngle = false; //allow to rotate when lifting head - effectively less friction 
		}
		else {
			rigidbody2D.fixedAngle = true;
		}

		distanceTraveled = transform.localPosition.x;
	}
	
	void FixedUpdate () {
	}
	
	void OnCollisionEnter () {
		touchingSurface = true;
	}
	
	void OnCollisionExit () {
		touchingSurface = false;
	}
}
