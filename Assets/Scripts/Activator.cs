using UnityEngine;
using System.Collections;

public class Activator : MonoBehaviour {

    public GameObject go;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            go.SetActive(true);
            Destroy(gameObject);
        }
    }
}
