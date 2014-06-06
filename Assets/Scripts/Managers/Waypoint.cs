using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour {

	internal Vector3 position;
	public float timeActivated;

	// Use this for initialization
	void Start () {
		position = transform.position;
	}

}
