using UnityEngine;
using System.Collections;

public class Granade : Bullet {

    public float range, time;
    public LayerMask mask;

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
            if (col.tag == "Enemy")
                col.GetComponent<Enemy>().DealDmg(Random.Range(minDmg, maxDmg));
            else if (col.tag == "Destroyable")
                col.GetComponent<DestroyableWall>().Destruction(transform.position, 10);
        }
        Destroy(gameObject);
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        
    }
}
