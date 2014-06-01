using UnityEngine;
using System.Collections;

public class TestSat : MonoBehaviour {

	public GameObject colorPlane;
	private ColorManipulator CM;
	
	// Use this for initialization
	void Start () {
		CM = colorPlane.GetComponent<ColorManipulator>();
	}
	
	void OnMouseDown ()
	{
		CM.IncreaseSaturation();
		print ("Sat");
	}
}
