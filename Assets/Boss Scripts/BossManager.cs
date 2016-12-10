﻿using UnityEngine;
using System.Collections;

public class BossManager : MonoBehaviour {

    public Vector3[] positions;
    public int current;

    public Transform BOSS;

    public float jumpHeight, jumpTime;

    void Start()
    {
        Transform pos = transform.GetChild(0);
        positions = new Vector3[pos.childCount];
        for (int i = 0; i < positions.Length; i++)
            positions[i] = pos.GetChild(i).position;
        BOSS.position = positions[0];
        current = 0;
    }

    public IEnumerator Jump()
    {
        Debug.Log("123");
        int index = current;
        while (index == current)
            index = Random.Range(0, positions.Length);

        float l = (60f * jumpTime);

        for(float i = 0; i < 60 * jumpTime; i++)
        {
            Vector3 position = new Vector3(
                Mathf.Lerp(positions[current].x, positions[index].x, i / l),
                jumpHeight * (1-Mathf.Abs(i - l/2) / (l/2)* Mathf.Abs(i - l / 2) / (l / 2)),
                Mathf.Lerp(positions[current].z, positions[index].z, i / l)
                );
            BOSS.position = position;
            yield return new WaitForSeconds(1f / 60f);
        }
        current = index;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(Jump());
    }

}