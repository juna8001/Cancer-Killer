using UnityEngine;
using System.Collections;

public class BoomEnemy : Enemy {

    [SerializeField]
    float range;
    [SerializeField]
    int minDmg, maxDmg;

    [SerializeField]
    GameObject boomPrefab;

    protected override void Update()
    {
        body.AddForce((Camera.main.transform.position - transform.position).normalized * speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, Movement.PlayerTransform.position) < range-1)
        {
            Die();

        }
    }
    [SerializeField]
    LayerMask mask;
    protected override void Die()
    {
        if (Vector3.Distance(transform.position, Movement.PlayerTransform.position) < range)
        {
            PlayerHealth.instance.dealDmg(Random.Range(minDmg, maxDmg));

        }
        Collider[] hits = Physics.OverlapSphere(transform.position, range, mask);
        foreach (Collider col in hits)
        {
            if(col.gameObject != gameObject)
            if (col.tag == "Enemy") {
                    Enemy enemy = col.GetComponent<Enemy>();
                    if(enemy.hp > 0)
                        enemy.DealDmg(Random.Range(minDmg, maxDmg)); 
            }
                else if (col.tag == "Destroyable")
                    col.GetComponent<DestroyableWall>().Destruction(transform.position, 10);
        }
        GameObject temp = (GameObject)Instantiate(boomPrefab, transform.position, new Quaternion());
        temp.GetComponent<ParticleSystem>().Play();
        base.Die();
    }
    
}
