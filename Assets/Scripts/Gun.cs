using UnityEngine;
using System.Collections;
using System;

public class Gun : MonoBehaviour, IWeapon
{
    private MeshRenderer rend;

    public GameObject bullet;
    public float bulletSpeed;
    public float shootTime;
    protected float lastShoot;
    public int maxBullets, Bullets;
    public int minDmg, maxDmg;


    void Awake()
    {
        rend = GetComponent<MeshRenderer>();
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
              go.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
            Bullet bull = go.GetComponent<Bullet>();
            bull.minDmg = minDmg;
            bull.maxDmg = maxDmg;
            }
    }

    public void SetChoosen(bool choosen)
    {
        rend.enabled = choosen;
    }
}
