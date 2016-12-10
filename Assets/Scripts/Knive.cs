﻿using UnityEngine;
using System.Collections;
using System;

public class Knive : MonoBehaviour, IWeapon
{
    private MeshRenderer rend;
    public float shootTime;
    float lastShoot;
    public float range;
    public LayerMask mask;
    public int minDmg, maxDmg;

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

            RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.forward, range, mask);
            foreach(RaycastHit hit in hits)
            {
                hit.collider.GetComponent<Enemy>().DealDmg(UnityEngine.Random.Range(minDmg, maxDmg));
            }
        }
    }
}
