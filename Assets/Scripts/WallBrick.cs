using UnityEngine;
using System.Collections;

public class WallBrick : MonoBehaviour {

	void Start()
    {
        StartCoroutine(destroyer());
    }

    IEnumerator destroyer()
    {
        while(transform.localScale.x > 0.1)
        {
            transform.localScale *= 0.95f;
            yield return new WaitForSeconds(0.02f);
        }
        Destroy(gameObject);
    }
}
