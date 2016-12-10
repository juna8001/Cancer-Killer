using UnityEngine;
using System.Collections;

public class Rifle : Gun {

    AudioSource[] sources;
    int sour = 0;

    protected override void Awake()
    {
        base.Awake();
        sources = GetComponents<AudioSource>();
        foreach (AudioSource s in sources)
            s.clip = clip;
    }

    public override void Shoot()
    {
        if (Bullets == 0)
        {
            if (Time.time - lastShoot > shootTime)
            {
                source.clip = emptyClip;
                source.Play();
                lastShoot = Time.time + 0.5f;
            }
        }
        else
            if (Time.time - lastShoot > shootTime)
        {
            Bullets--;
            sources[sour].Play();
            sour = (sour + 1) % sources.Length;
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

}
