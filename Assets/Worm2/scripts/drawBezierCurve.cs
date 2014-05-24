using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Controls the drawing of the curve between the child GameObjects of this one

public class drawBezierCurve : MonoBehaviour {
	public static float distanceTraveled;

	public Transform tracked;
	public Transform segmentPrefab;

    //public LineRenderer line = new LineRenderer();
	public int a;
    public float curVarValue;
    public int numPieces;

	private List<Transform> segments = new List<Transform>();

    void Start () {
        /*line = gameObject.AddComponent<LineRenderer>();
        line.material = new Material(Shader.Find("Particles/Alpha Blended"));
        line.SetWidth(3F, 3F);
        line.SetColors(Color.gray, Color.yellow);
        line.SetVertexCount(lineRes);*/

		for (int p = 0; p < numPieces; p++) {

			//var newseg = Instantiate (segmentPrefab, tempLoc, Quaternion.identity) as GameObject;
			//newseg.name = "Segment " + p; 
			segments.Add ( (Transform)Instantiate (segmentPrefab) );
		}

		var AM = AudioManager.Instance;
    }

    List<Vector3> getBezierControlPoints () {
        List<Vector3> templist = new List<Vector3>();

        foreach (Transform child in transform) { //All child gameObjects are used as control points for calculating the Bezier curve
            templist.Add(new Vector3 (child.transform.position.x, child.transform.position.y, child.transform.position.z) );
        }
        return templist;
    }

    void Update () {
        Vector3[] controlPoints = new Vector3[] {};
        controlPoints = getBezierControlPoints().ToArray();
        SplineBuilder curve = new SplineBuilder(controlPoints);

		foreach (Transform seg in segments) {
			int segID = segments.IndexOf (seg);

			Vector3 pos = curve.Lerp ( (segID + .5f) / numPieces);
			Vector3 lookLoc = curve.Lerp ( (segID + .25f) / numPieces);
			seg.localPosition = pos;
			seg.LookAt (lookLoc, Vector3.back);
        }

		distanceTraveled = tracked.localPosition.x * transform.localScale.x; //Normalize by scale -- double size objects move twice as much, relative to the scene!
    }
}


public class SplineBuilder {
    public Vector3[] pts;

    public SplineBuilder (params Vector3[] pts) {
        this.pts = new Vector3[pts.Length];
        System.Array.Copy (pts, this.pts, pts.Length);
    }


    public Vector3 Lerp (float t) { //Returns vector coordinates of position t (from 0f to 1f) along the bezier curve
        int numSections = pts.Length - 3;
        int curPoint = Mathf.Min (Mathf.FloorToInt (t * (float)numSections), numSections - 1);
        float u = t * (float)numSections - (float)curPoint;

        Vector3 a = pts[curPoint];
        Vector3 b = pts[curPoint + 1];
        Vector3 c = pts[curPoint + 2];
        Vector3 d = pts[curPoint + 3];

        return .5f * ((-a + 3f * b - 3f * c + d) * (u * u * u) + (2f * a - 5f * b + 4f * c - d) * (u * u) + (-a + c) * u + 2f * b);
    }
}