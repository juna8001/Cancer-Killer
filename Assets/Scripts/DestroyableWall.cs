using UnityEngine;
using System.Collections;

public class DestroyableWall : MonoBehaviour {

	public void Destruction(Vector3 from, float force)
    {
        GetComponent<BoxCollider>().enabled = false;
        for(int i = 0; i < transform.childCount; i++)
        {
            Transform t = transform.GetChild(i);
            Rigidbody rb = t.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.AddForce((transform.position - from).normalized * force, ForceMode.Impulse);
            t.gameObject.AddComponent<WallBrick>();
        }
    }

}
