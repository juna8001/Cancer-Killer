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

    void Awake()
    {
        rend = GetComponent<MeshRenderer>();
    }

    public void Shoot()
    {
        if(Time.time - lastShoot > shootTime)
        {
            lastShoot = Time.time;
            GameObject go = Instantiate<GameObject>(bullet);
            go.transform.position = transform.position;
            go.transform.rotation = transform.rotation;
            go.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
        }
    }

    public void Reload()
    {
        throw new NotImplementedException();
    }

    public void SetChoosen(bool choosen)
    {
        rend.enabled = choosen;
    }
}
