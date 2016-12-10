using UnityEngine;
using System.Collections;

public class Granade : Bullet {

    public float range, time;
    public LayerMask mask;

    [SerializeField]
    private GameObject explosion;

    protected override void Start()
    {
        StartCoroutine(counter());
    }

    IEnumerator counter()
    {
        yield return new WaitForSeconds(time);
        Collider[] hits = Physics.OverlapSphere(transform.position, range, mask);
        foreach(Collider col in hits)
        {
            col.GetComponent<Enemy>().DealDmg(Random.Range(minDmg, maxDmg));
        }
        GameObject temp = (GameObject)Instantiate(explosion, transform.position, new Quaternion());
        temp.GetComponent<ParticleSystem>().Play();
        Destroy(gameObject);
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        
    }
}
