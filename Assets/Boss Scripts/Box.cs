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

    protected override void Start()
    {
        
    }
    [SerializeField]
    int dmg;

    public GameObject explosion;
    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 6);
            foreach (Collider col in colliders)
                if (col.tag == "Enemy")
                    col.GetComponent<Enemy>().DealDmg(dmg);
            GameObject temp = (GameObject)Instantiate(explosion, transform.position, new Quaternion());
            temp.transform.localScale = Vector3.one * 2;
            temp.GetComponent<ParticleSystem>().Play();
            Destroy(gameObject);
        }
    }
}
