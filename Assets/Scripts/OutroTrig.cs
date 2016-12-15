using UnityEngine;
using System.Collections;

public class OutroTrig : MonoBehaviour {

	public Animator anim;
	// Use this for initialization
	void Start () {
		anim.SetTrigger("out");
	}
	

}
