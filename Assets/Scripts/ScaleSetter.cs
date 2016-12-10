using UnityEngine;
using System.Collections;

public class ScaleSetter : MonoBehaviour {
	
	private Material material;
	
	void Awake()
	{
		material = GetComponent<Renderer>().material;
	}
	
	void Update () {
		material.SetFloat("_ScaleX", transform.localScale.x);
		material.SetFloat("_ScaleY", transform.localScale.y);
	}
}
