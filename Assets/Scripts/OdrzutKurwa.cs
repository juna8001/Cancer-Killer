using UnityEngine;
using System.Collections;

public class OdrzutKurwa : MonoBehaviour {

    public static OdrzutKurwa instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        mainEulerAngles = weapon.localEulerAngles;
    }

    public Transform weapon;

    Vector3 mainEulerAngles;

    Vector3 kick;

    public void Kick(float x)
    {
        kick.x -= x;
    }

    void FixedUpdate()
    {
        kick *= 0.9f;
        weapon.localEulerAngles = mainEulerAngles + kick;
    }
}
