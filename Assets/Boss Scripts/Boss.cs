using UnityEngine;
using System.Collections;

public class Boss : Enemy {

    public GameObject text;

	void Awake() { }
#pragma warning disable CS0114 // Member hides inherited member; missing override keyword
    void Update() { }
#pragma warning restore CS0114 // Member hides inherited member; missing override keyword

    protected override void Start()
    {
        
    }

    public override void DealDmg(int dmg)
    {
        base.DealDmg(dmg);
    }

    protected override void Die()
    {
        Instantiate(text);
        transform.parent.GetComponent<BossManager>().BossDeath();
        Destroy(gameObject);
    }
}
