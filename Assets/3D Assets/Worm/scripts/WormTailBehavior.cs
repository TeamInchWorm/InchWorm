using UnityEngine;
using System.Collections;

public class WormTailBehavior : MonoBehaviour
{
	
	public static float distanceTraveled;
	
	private bool touchingSurface;
	
	public Vector2 jumpVelocity;
	public Transform mid;

	void Update () {
		if (Input.GetAxis ("Horizontal") < 0) { // Left
			rigidbody2D.AddForce (jumpVelocity * Time.deltaTime * Mathf.Pow(2f, (mid.localPosition.y - transform.localPosition.y - 2f) ) );

			rigidbody2D.fixedAngle = false; //allow to rotate when lifting tail - effectively less friction
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
