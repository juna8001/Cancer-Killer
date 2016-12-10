using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    public int minDmg, maxDmg;
    public float existTime = 10;

    protected virtual void Start()
    {
        StartCoroutine(destroyer());
    }

    IEnumerator destroyer()
    {
        yield return new WaitForSeconds(existTime);
        Destroy(gameObject);
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
            collision.gameObject.GetComponent<Enemy>().DealDmg(Random.Range(minDmg, maxDmg));
        Destroy(gameObject);
    }
}