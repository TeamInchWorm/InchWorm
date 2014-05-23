using UnityEngine;
using System.Collections;

public class Worm : MonoBehaviour {

	public static float distanceTraveled;

	public float acceleration;

	private bool touchingSurface;

	public Vector3 jumpVelocity;

	// Update is called once per frame
	void Update () {
		if(/*touchingSurface && */Input.GetButtonDown("Jump")){
			rigidbody2D.AddForce(jumpVelocity);
		}

		distanceTraveled = transform.localPosition.x;
	}

	void FixedUpdate () {
		//if(touchingSurface){
			rigidbody2D.AddForce(Vector2.right * acceleration);
		//}
	}
	
	void OnCollisionEnter () {
		touchingSurface = true;
	}
	
	void OnCollisionExit () {
		touchingSurface = false;
	}
}
