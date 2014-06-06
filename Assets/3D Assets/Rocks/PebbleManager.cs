using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PebbleManager : MonoBehaviour {
	
	public Transform [] feature;
	public int numberOfRocks;
	public float recycleOffset;
	public float startRocksTime;
	public Vector3 startPosition;
	public Vector3 minSize, maxSize, minGap, maxGap;
	public Vector3 minPosition, maxPosition;
	
	private Vector3 nextPosition;
	private Queue<Transform> objectQueue;
	private bool rocksOn = false;
	private int counter;
	private int totalRockNumber;
	
	void Start () {
		//GameEventManager.GameStart += TriggerFXZero;
		GameEventManager.TimeChange += checkTime;
	}
	
	void Update () {
		if (rocksOn && objectQueue.Peek().localPosition.x + recycleOffset < drawBezierCurve.distanceTraveled) {
			Recycle();
		}
	}
	
	private void Recycle () {
		float baseSize = Random.Range (1f, 4f);

		Vector3 scale = new Vector3 (Random.Range (minSize.x, maxSize.x + baseSize * 2f),
		                             Random.Range (minSize.y, maxSize.y + baseSize),
		                             Random.Range (minSize.z, maxSize.z + baseSize * 2f) );
		
		Vector3 position = nextPosition;
		position.x += scale.x * 0.5f;
		position.y += scale.y * 0.5f;
		
		Transform o = objectQueue.Dequeue();
		o.localScale = scale;
		o.localPosition = position;
		
		objectQueue.Enqueue(o);

		o.Rotate (Random.Range (0f, 360f), 0f, 0f);

		nextPosition += new Vector3 (Random.Range (minGap.x, maxGap.x) + scale.x,
		                             Random.Range (minGap.y, maxGap.y),
		                             Random.Range (minGap.z, maxGap.z) );

		//Make sure the relocated objects remain in the acceptable band of Y & Z positions
		while (nextPosition.y < minPosition.y) {
			nextPosition.y += 1f;
		}
		while (nextPosition.y > maxPosition.y) {
			nextPosition.y -= 1f;
		}

		while (nextPosition.z < minPosition.z) {
			nextPosition.z += 1f;
		}
		while (nextPosition.z > maxPosition.z) {
			nextPosition.z -= 1f;
		}
	}

	private void checkTime (float currentTime) {
		if (!rocksOn && currentTime >= startRocksTime) 
			EnableRocks();

		if (currentTime > totalRockNumber) 
			totalRockNumber++;
	}

	private void EnableRocks () {
		rocksOn = true;

		totalRockNumber = numberOfRocks;

		objectQueue = new Queue<Transform> (numberOfRocks);
		for (int i = 0; i < totalRockNumber; i++) {
			// Add a random one of the feature prefabs to the scene
			objectQueue.Enqueue ( (Transform)Instantiate (feature [Random.Range (0, feature.Length) ] ) );
		}
		
		nextPosition = startPosition;
		
		for (int i = 0; i < totalRockNumber; i++) {
			Recycle();
		}
	}
}
