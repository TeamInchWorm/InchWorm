using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FeatureManager : MonoBehaviour {

	public Transform [] feature;
	public Material textureMaterial;
	public int numberOfObjects;
	public float recycleOffset;
	public Vector3 startPosition;
	public Vector3 minSize, maxSize;
	public float minGap, maxGap;
	
	private Vector3 nextPosition;
	private Queue<Transform> objectQueue;
	
	void Start () {
		objectQueue = new Queue<Transform> (numberOfObjects);
		for (int i = 0; i < numberOfObjects; i++) {
			// Add a random one of the prefab features to the scene
			objectQueue.Enqueue ( (Transform)Instantiate (feature [Random.Range (0, feature.Length) ] ) );
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
		float baseSize = Random.Range (0.25f, 1.5f);
	
		Vector3 scale = new Vector3 (Random.Range(minSize.x, maxSize.x) + baseSize * 2f,
		                             Random.Range(minSize.y, maxSize.y) + baseSize,
		                             Random.Range(minSize.z, maxSize.z) + baseSize * 3f);
		
		Vector3 position = nextPosition;
		//position.x += scale.x * 0.5f;
		//position.y += scale.y * 0.5f;
		
		Transform o = objectQueue.Dequeue();
		o.localScale = scale;
		o.localPosition = position;
		o.Rotate (0f, 0f, Random.Range (0f, 360f) );
		o.renderer.material = textureMaterial;
		nextPosition.x += scale.x + Random.Range (minGap, maxGap);

		objectQueue.Enqueue(o);
	}
}
