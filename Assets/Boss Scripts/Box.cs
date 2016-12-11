using UnityEngine;
using System.Collections;

public class Box : Enemy {

    protected override void Die()
    {
        
    }
    protected override void Update()
    {
        
    }
    public override void DealDmg(int dmg)
    {
        tag = "Untagged";
        gameObject.layer = SortingLayer.GetLayerValueFromName("Bullet");
        GetComponent<Rigidbody>().isKinematic = false;
    }

    protected override void Awake()
    {
        
    }
    [SerializeField]
    int dmg;
    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().DealDmg(dmg);
            Destroy(gameObject);
        }
    }
}
