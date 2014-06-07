using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour {

	internal Vector3 position;
	public float timeActivated;
	public float transitionTime = 1.0f;

	// Use this for initialization
	void Start () {
		position = transform.position;
	}

	void Update () {
		position = transform.position;
	}

}
