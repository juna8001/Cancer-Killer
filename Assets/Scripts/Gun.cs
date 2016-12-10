using UnityEngine;
using System.Collections;
//using System;

public class Gun : MonoBehaviour, IWeapon
{


    public GameObject bullet;
    public float bulletSpeed;
    public float shootTime;
    protected float lastShoot;
    public int maxBullets, Bullets;
    public int minDmg, maxDmg;
    public float shootAngle = 0.1f;

    private MeshRenderer rend;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    void Awake()
    {
        rend = GetComponent<MeshRenderer>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInParent<Animator>();
    }

    public virtual void Shoot()
    {
        if (Bullets == 0)
        {
        } else
            if(Time.time - lastShoot > shootTime)
            {
                Bullets--;
                lastShoot = Time.time;
                GameObject go = Instantiate<GameObject>(bullet);
                go.transform.position = transform.position;
                go.transform.rotation = transform.rotation;
                go.transform.Rotate(new Vector3(Random.Range(-shootAngle, shootAngle), Random.Range(-shootAngle, shootAngle), 0));
              go.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
            Bullet bull = go.GetComponent<Bullet>();
            bull.minDmg = minDmg;
            bull.maxDmg = maxDmg;
            Animate("Gun");
            }
    }

    public void SetChoosen(bool choosen)
    {
        //rend.enabled = choosen;
        spriteRenderer.enabled = choosen;
    }

    public void Animate(string animName)
    {
        animator.SetTrigger(animName);
    }

    public int getAmmo()
    {
        return Bullets;
    }

    public int maxAmmo()
    {
        return maxBullets;
    }
}
