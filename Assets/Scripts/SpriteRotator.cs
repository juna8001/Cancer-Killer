using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class SpriteRotator : MonoBehaviour {

	void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
    }
}
