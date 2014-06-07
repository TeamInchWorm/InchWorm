using UnityEngine;
using System.Collections;

public class DistanceTraveled : MonoBehaviour {
	
	public float scoreMultiplier = .0015f;
	public float scoreDecrementor = -0.01f;
	
	private GameEventManager GM;
	private float xPos, xLast, maxDistReached;

	// Use this for initialization
	void Start () {
		GM = GameObject.Find("Game Event Manager").GetComponent<GameEventManager>();

		xPos = transform.position.x;
		maxDistReached = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {

		xLast = xPos;
		xPos = transform.position.x;
		
		float dist = xPos - xLast;

		print ("xLast: " + xLast + "  xPos: " + xPos + "  dist: " + dist);
	
		if (xPos > maxDistReached) {
			GM.ChangeScore(dist * scoreMultiplier); 

			maxDistReached = xPos;
		}
		//else if (dist <= 0 && dist >= -0.1)
		//	GM.ChangeScore(scoreDecrementor);

	}


}
