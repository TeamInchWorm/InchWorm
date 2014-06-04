using UnityEngine;
using System.Collections;

public class DistanceTraveled : MonoBehaviour {

	private float xPos, xLast;
	private GameEventManager GM;


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

		if (dist != 0)
			GM.ChangeScore(dist); 

		else
			GM.ChangeScore(-0.1f);			
	}


}
