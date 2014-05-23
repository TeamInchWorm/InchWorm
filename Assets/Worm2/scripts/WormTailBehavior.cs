using UnityEngine;
using System.Collections;

public class WormTailBehavior : MonoBehaviour
{
	
	public static float distanceTraveled;
	
	private bool touchingSurface;
	
	public Vector2 jumpVelocity;
	
	//void OnMouseDrag()
	//{
	//    transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
	//}
	
	void Update () {
		if(Input.GetAxis("Horizontal") < 0) { // Left
			rigidbody2D.AddForce(jumpVelocity / (transform.localPosition.y + 3f) * 3f);

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
