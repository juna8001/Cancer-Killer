using UnityEngine;
using System.Collections;
using System;

public class Knive : MonoBehaviour, IWeapon
{
    private MeshRenderer rend;
    public float shootTime;
    float lastShoot;

    public void SetChoosen(bool choosen)
    {
        rend.enabled = choosen;
    }

    void Awake()
    {
        rend = GetComponent<MeshRenderer>();
    }

    public void Shoot()
    {
        if(Time.time - lastShoot > shootTime)
        {
            lastShoot = Time.time;
        }
    }
}
