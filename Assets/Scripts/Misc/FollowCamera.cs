using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {
	public Transform target; //What gameObject camera should track

	public float smoothingRate; //How quickly camera should converge on target; 0 = instant, 200 is slow

	// Use this for initialization
	void Start () {
	
	}

	void Update () {

		transform.position = new Vector3(Mathf.Lerp (transform.position.x, target.position.x, 1f/(smoothingRate + 1f)),
		                                 Mathf.Lerp (transform.position.y, target.position.y+24f, 1f/(smoothingRate + 1f)), 
		                                 transform.position.z);
	}

	// Public delegate void pointEventHandler (int points);
	//Declare a delegate which is a template of the types
	// Declare public static event - which other things subscribe to them
	// then other things subscribe to them to trigger then
	// like if had player class and health variable
	// if player.health <= 0, trigger level end event
	// public static void triggerlevelcomplete(){
	// 
	// awake () {
	// GameManager.levelStart += FunctionToBeCalled;
	// LevelComplete += LevelComplete;

	//public static void TriggerLevelStart()

			// in awake function:
			// levelstart += levelstart;

			// private void levelStart()
}
