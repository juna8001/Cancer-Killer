using UnityEngine;
using System.Collections;

public class BossManager : MonoBehaviour {

    public Vector3[] positions;
    public int current;

    public Transform BOSS;

    public float jumpHeight, jumpTime;

    public GameObject spawnedEnemyPrefab, boomEnemyPrefab;

    void Start()
    {
        Transform pos = transform.GetChild(0);
        positions = new Vector3[pos.childCount];
        for (int i = 0; i < positions.Length; i++)
            positions[i] = pos.GetChild(i).position;
        BOSS.position = positions[0];
        current = 0;
    }

    public void Jump()
    {
        StartCoroutine(jump());
    }

    IEnumerator jump()
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
                Mathf.Lerp(positions[current].y, positions[index].y, i / l) + jumpHeight * (1-Mathf.Abs(i - l/2) / (l/2)* Mathf.Abs(i - l / 2) / (l / 2)),
                Mathf.Lerp(positions[current].z, positions[index].z, i / l)
                );
            BOSS.position = position;
            yield return new WaitForSeconds(1f / 60f);
        }
        current = index;
    }

    public void Spawn1()
    {
        int ammount = Random.Range(3, 9);
        for(int i = 0; i < ammount; i++)
        {
            Instantiate(spawnedEnemyPrefab, BOSS.position + BOSS.TransformVector(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, -10f)), BOSS.rotation);
        }
    }

    public void Spawn2()
    {
        int ammount = Random.Range(3, 9);
        for (int i = 0; i < ammount; i++)
        {
            Instantiate(boomEnemyPrefab, BOSS.position + BOSS.TransformVector(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, -10f)), BOSS.rotation);
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Spawn1();
        if (Input.GetKeyDown(KeyCode.Alpha2))
            Spawn2();
    }

}
