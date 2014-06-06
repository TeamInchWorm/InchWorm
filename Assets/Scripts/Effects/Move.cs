using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Move : MonoBehaviour {

	public Waypoint[] sceneMovements;
	public bool cameraJump;
	private Queue<Waypoint> queuedMovements;
	private int test;
	private float nextEventTime;

	// Use this for initialization
	void Start () {
		GameEventManager.TimeChange += SceneHandler; // add SceneHandler method to TimeChange's list of follower events

		queuedMovements = new Queue<Waypoint>(sceneMovements.Length);

		for (int i = 0; i < sceneMovements.Length; i++) {
			queuedMovements.Enqueue (sceneMovements[i]);
		}
		if (queuedMovements.Count > 0)
			nextEventTime = queuedMovements.Peek().timeActivated;
	}

	public void StartNextMovement() {
		if (queuedMovements.Count > 0){
			Waypoint nextLocation = queuedMovements.Dequeue();

			if (cameraJump)
				transform.position = nextLocation.position;
			else
				StartCoroutine(MoveTo (nextLocation.position));
		}
	}

	//Move an object to a new position
	IEnumerator MoveTo(Vector3 targetPosition) {
		//Initialize a velocity for smooth damp
		var velocity = Vector3.zero;
		//While we are not near to the target
		while((transform.position - targetPosition).sqrMagnitude > 0.01 * 0.01) {
			//Use smooth damp to move to the new position
			transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, 1);
			//Yield until the next frame
			yield return null;
		}
	}

	private void SceneHandler(float currentTime) {
		// go to next position
		if (nextEventTime <= currentTime) {
			StartNextMovement();

			if (queuedMovements.Count > 0)
				nextEventTime = queuedMovements.Peek().timeActivated;
		}
	}


}
