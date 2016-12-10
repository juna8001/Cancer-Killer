using UnityEngine;
using System.Collections;

public class OfensiveEnemy : Enemy {

    public float attackTime, range;
    public int minDmg, maxDmg;

    float lastHit;

    protected override void Update()
    {
        body.AddForce((Camera.main.transform.position - transform.position).normalized * speed * Time.deltaTime);
        if(Time.time - lastHit > attackTime && Vector3.Distance(transform.position, Movement.PlayerTransform.position) < range){

            lastHit = Time.time;
            Debug.Log(name);
            PlayerHealth.instance.dealDmg(Random.Range(minDmg, maxDmg));

        }
    }

    

}
