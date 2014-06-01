using UnityEngine;
using System.Collections;

public class ColorManipulator : MonoBehaviour {

	[Range (0, 1)]
	public float opacity = 1.0f; 

	private const float OPACITYMIN = 0.0f;
	private const float OPACITYMAX = 1.0f;

	private Color col;

	// Use this for initialization
	void Start () {
		col = gameObject.renderer.material.color;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void IncreaseSaturation(float step = 0.1f)
	{
		ChangeOpacity(step);		
	}

	public void DecreaseSaturation(float step = 0.1f)
	{
		ChangeOpacity(step * -1.0f);
	}

	private void ChangeOpacity(float step)
	{
		opacity = Mathf.Clamp(opacity + step, OPACITYMIN, OPACITYMAX); 
		col.a = opacity;
		gameObject.renderer.material.color = col;
	}


}
