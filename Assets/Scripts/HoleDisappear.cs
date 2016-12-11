using UnityEngine;
using System.Collections;

public class HoleDisappear : MonoBehaviour {

	// Use this for initialization
	void Start () {

        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(go());

	}

    SpriteRenderer sr;
	
	IEnumerator go()
    {
        while (sr.color.a > 0)
        {
            yield return new WaitForSeconds(0.2f);
            Color c = sr.color;
            c.a-=0.01f;
            sr.color = c;
        }
        Destroy(gameObject);
    }
}
