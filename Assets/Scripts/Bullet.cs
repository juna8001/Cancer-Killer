using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    public int minDmg, maxDmg;
    public float existTime = 10;

    void Start()
    {
        StartCoroutine(destroyer());
    }

    IEnumerator destroyer()
    {
        yield return new WaitForSeconds(existTime);
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
            Debug.Log("Deal " + Random.Range(minDmg, maxDmg) + " dmg to " + collision.gameObject.name);
        Destroy(gameObject);
    }
}