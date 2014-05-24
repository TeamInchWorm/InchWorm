using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FeatureManager : MonoBehaviour {

	public Transform prefab;
	public int numberOfObjects;
	public float recycleOffset;
	public Vector3 startPosition;
	public Vector3 minSize, maxSize;
	public float spaceMin, spaceMax;
	
	private Vector3 nextPosition;
	private Queue<Transform> objectQueue;
	
	void Start () {
		objectQueue = new Queue<Transform>(numberOfObjects);
		for (int i = 0; i < numberOfObjects; i++) {
			objectQueue.Enqueue((Transform)Instantiate(prefab));
		}
		nextPosition = startPosition;
		for (int i = 0; i < numberOfObjects; i++) {
			Recycle();
		}
	}
	
	void Update () {
		if (objectQueue.Peek().localPosition.x + recycleOffset < drawBezierCurve.distanceTraveled) {
			Recycle();
		}
	}
	
	private void Recycle () {
		float baseSize = Random.Range(0f, 2f);
	
		Vector3 scale = new Vector3(
			Random.Range(minSize.x, maxSize.x) + baseSize,
			Random.Range(minSize.y, maxSize.y) + baseSize,
			Random.Range(minSize.z, maxSize.z) + baseSize*2f);
		
		Vector3 position = nextPosition;
		position.x += scale.x * 0.5f;
		position.y += scale.y * 0.5f;
		
		Transform o = objectQueue.Dequeue();
		o.localScale = scale;
		o.localPosition = position;
		o.Rotate (0f, 0f, Random.Range (0f, 360f));
		nextPosition.x += scale.x + Random.Range(spaceMin, spaceMax);

		objectQueue.Enqueue(o);
	}
}
