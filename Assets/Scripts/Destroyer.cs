using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

    public float ExistTime;

    void Start()
    {
        StartCoroutine(destroyer());
    }

    IEnumerator destroyer()
    {
        yield return new WaitForSeconds(ExistTime);
        
        Destroy(gameObject);
    }
}
