﻿using UnityEngine;
using System.Collections;

public class ShotGun : Gun {

    public int shoots;

    public override void Shoot()
    {
        if (Bullets == 0)
        {
        }
        else
            if (Time.time - lastShoot > shootTime)
        {
            Bullets--;
            lastShoot = Time.time;
            for(int i = 0; i < shoots; i++)
            {
                GameObject go = Instantiate<GameObject>(bullet);
                go.transform.position = transform.position;
                go.transform.rotation = transform.rotation;
                go.transform.Rotate(new Vector3(Random.Range(-shootAngle, shootAngle), Random.Range(-shootAngle, shootAngle), 0));
                go.GetComponent<Rigidbody>().velocity = go.transform.forward * bulletSpeed;
                Bullet bull = go.GetComponent<Bullet>();
                bull.minDmg = minDmg;
                bull.maxDmg = maxDmg;
                Animate("ShotGun");
            }
        }
    }
}
