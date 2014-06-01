using UnityEngine;
using System.Collections;

public class TestDesat : MonoBehaviour {

	public GameObject colorPlane;
	private ColorManipulator CM;

	// Use this for initialization
	void Start () {
		CM = colorPlane.GetComponent<ColorManipulator>();
	}

	void OnMouseDown ()
	{
		CM.DecreaseSaturation();
		print ("Desat");
	}
}
