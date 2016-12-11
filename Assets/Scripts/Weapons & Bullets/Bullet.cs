using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    public int minDmg, maxDmg;
    public float existTime = 10;

    public GameObject hole;

    [SerializeField]
    private GameObject bloodSplash;

    protected virtual void Start()
    {
        StartCoroutine(destroyer());
    }

    public IEnumerator destroyer()
    {
        yield return new WaitForSeconds(existTime);
        Destroy(gameObject);
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().DealDmg(Random.Range(minDmg, maxDmg));
            GameObject temp = (GameObject)Instantiate(bloodSplash, transform.position, new Quaternion());
            temp.GetComponent<ParticleSystem>().Play();
        } else if(collision.gameObject.tag != "Player")
        {
            if(hole != null)
            {
                GameObject go = (GameObject) Instantiate(hole, collision.contacts[0].point, Quaternion.LookRotation(collision.contacts[0].normal));
                go.transform.position += go.transform.forward * 0.02f;
                go.transform.localScale = Vector3.one * 0.5f;
            }
        }
        if(collision.gameObject.tag != "Player")
        Destroy(gameObject);
    }
}