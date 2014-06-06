using UnityEngine;
using System.Collections;

public class DistanceTraveled : MonoBehaviour {

	private float xPos, xLast;
	private GameEventManager GM;

	public float scoreMultiplier = 1.5f;
	public float scoreDecrementor = -0.01f;

	// Use this for initialization
	void Start () {
		GM = GameObject.Find("Game Event Manager").GetComponent<GameEventManager>();
		xPos = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {

		xLast = xPos;
		xPos = transform.position.x;

		float dist = xPos - xLast;

		if (dist > 0)
			GM.ChangeScore(dist * scoreMultiplier); 
		else if (dist <= 0 && dist >= -0.1)
			GM.ChangeScore(scoreDecrementor);

	}


}
