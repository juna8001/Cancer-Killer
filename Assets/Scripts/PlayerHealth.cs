using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    [SerializeField]
    public int hp;

    public static PlayerHealth instance;

    void Awake()
    {
        instance = this;
    }

    public void dealDmg(int dmg)
    {
        hp -= dmg;
        if (hp <= 0)
            die();
    }

    void die()
    {
        Debug.Log("Player Death");
    }
}
