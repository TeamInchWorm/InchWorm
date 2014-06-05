using UnityEngine;
using System.Collections;

public class StringBehavior : MonoBehaviour {
	
	public static float reductionLimit = .55f;
	public static float reduceScale = .75f;
	public static float returnRate = 2f;

	public float initialLen;
	public float rightLen, leftLen;

	public Transform leftObj, rightObj; 

	private float rightTimeHeld, leftTimeHeld, timeReleased;
	private bool rightPressed, leftPressed;
	//private bool leftReleasing, rightReleasing;

	private float prevLen;
	
	//void OnMouseDrag()
	//{
	//    transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
	//}

	void Start () {
		prevLen = initialLen;
		timeReleased = 0f;
	}
		
	void Update () {
		if (Input.GetAxis("Horizontal") > 0) { // Right
			if(!rightPressed) {
				rightTimeHeld = Time.time;
				prevLen = transform.localScale.y;
			}
			rightPressed = true;

			if(initialLen != rightLen)
				transform.localScale = new Vector3(transform.localScale.x, 
				                                   Mathf.Lerp (prevLen, rightLen, horizAsymptote ( (Time.time - rightTimeHeld) * Mathf.Sqrt (rightObj.localPosition.y + leftObj.localPosition.y + 4f) / reduceScale, reductionLimit)), 
				                                   transform.localScale.z);
		}
		else if (Input.GetAxis ("Horizontal") < 0) { // Left
			if (!leftPressed) {
				leftTimeHeld = Time.time;
				prevLen = transform.localScale.y;
			}
			leftPressed = true;

			if (initialLen != leftLen)
				transform.localScale = new Vector3 (transform.localScale.x, 
				                                    Mathf.Lerp (prevLen, leftLen, horizAsymptote ( (Time.time - leftTimeHeld) * Mathf.Sqrt (leftObj.localPosition.y + leftObj.localPosition.y + 4f) / reduceScale, reductionLimit)),
				                                    transform.localScale.z);
		}
		else { // neither left nor right
			if (leftPressed || rightPressed) {		// L/R had until now been held, so
				timeReleased = Time.time;			// record the time
				prevLen = transform.localScale.y;	// and length upon this release
			}

			leftPressed = false;
			rightPressed = false;

			transform.localScale = new Vector3 (transform.localScale.x, 
			                                    Mathf.Lerp (prevLen, initialLen, (Time.time - timeReleased) * returnRate), 
			                                    transform.localScale.z);
		}

	}
	
	void FixedUpdate () {
	}
	
	//void OnCollisionEnter () {
	//	touchingSurface = true;
	//}
	
	//void OnCollisionExit () {
	//	touchingSurface = false;
	//}

	float horizAsymptote (float x, float target) {
		return (target - target / (x + 1f));
	}


}
