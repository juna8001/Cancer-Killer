using UnityEngine;
using System.Collections;
using System;

public class Gun : MonoBehaviour, IWeapon
{
    private MeshRenderer rend;

    public GameObject bullet;
    public float bulletSpeed;
    public float shootTime;
    float lastShoot;
    public float reloadTime;
    public int maxBullets, Bullets, maxBulletsIn, BulletsIn;


    void Awake()
    {
        rend = GetComponent<MeshRenderer>();
    }

    public void Shoot()
    {
        if (BulletsIn == 0)
        {
            if (Bullets > 0)
                Reload();
        } else
            if(Time.time - lastShoot > shootTime)
            {
                BulletsIn--;
                lastShoot = Time.time;
                GameObject go = Instantiate<GameObject>(bullet);
                go.transform.position = transform.position;
                go.transform.rotation = transform.rotation;
              go.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
            }
    }

    public void Reload() // kod poprawię jak się wyśpię
    {
        if(Bullets > 0)
        {
            if(Bullets >= maxBulletsIn)
            {
                Bullets -= maxBulletsIn - BulletsIn;
                BulletsIn = maxBulletsIn;
            }else
            {
                int x = Mathf.Min(maxBulletsIn - BulletsIn, Bullets);
                Bullets -= x;
                BulletsIn += x;
            }
        }
    }

    public void SetChoosen(bool choosen)
    {
        rend.enabled = choosen;
    }
}
