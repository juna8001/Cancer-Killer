﻿using UnityEngine;
using System.Collections;
using System;

public class Knive : MonoBehaviour, IWeapon
{
    
    public float shootTime;
    float lastShoot;
    public float range;
    public LayerMask mask;
    public int minDmg, maxDmg;

    [SerializeField]
    private GameObject bloodSplash;

    private MeshRenderer rend;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    public AudioClip clip;
    protected AudioSource source;

    public void SetChoosen(bool choosen)
    {
        //rend.enabled = choosen;
        spriteRenderer.enabled = choosen;
    }

    void Awake()
    {
        rend = GetComponent<MeshRenderer>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInParent<Animator>();
        source = GetComponent<AudioSource>();
        source.clip = clip;
    }

    public void Shoot()
    {
        if(Time.time - lastShoot > shootTime)
        {
            lastShoot = Time.time;

            source.Play();

            RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.forward, range, mask);
            Animate("Knife");
            foreach(RaycastHit hit in hits)
            {
                hit.collider.GetComponent<Enemy>().DealDmg(UnityEngine.Random.Range(minDmg, maxDmg));
                GameObject temp = (GameObject)Instantiate(bloodSplash, hit.point, new Quaternion());
                temp.GetComponent<ParticleSystem>().Play();
            }
        }
    }

    public void Animate(string animName)
    {
        animator.SetTrigger(animName);
    }

    public int getAmmo()
    {
        return 0;
    }

    public int maxAmmo()
    {
        return 0;
    }
}
