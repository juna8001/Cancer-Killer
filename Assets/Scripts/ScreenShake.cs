﻿using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour {

	public static ScreenShake Instance;

	public Animator animator;

	void Awake () {
		if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            if(Instance != this)
                Destroy(this);
        }
		animator = GetComponent<Animator>();
	}
}
