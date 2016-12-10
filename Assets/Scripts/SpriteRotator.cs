using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class SpriteRotator : MonoBehaviour {

	void Update()
    {
        transform.rotation = Camera.main.transform.rotation;
    }
}
