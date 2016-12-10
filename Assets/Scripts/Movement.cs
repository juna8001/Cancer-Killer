using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public float Speed;

    private Vector3 direction;
    public Vector3 Direction
    {
        get { return direction; }
        set { direction = value.normalized; }
    }

    [HideInInspector]
    public Vector2 Rotation;

    [HideInInspector]
    public Transform Head;

    private Rigidbody body;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        Head = transform.GetChild(0).transform;
    }

    void FixedUpdate()
    {
        body.velocity = transform.TransformVector(direction) * Speed;
        transform.Rotate(transform.up, Rotation.x);
        float angle = Head.localRotation.eulerAngles.x + Rotation.y;
        if (angle > 180)
            angle -= 360;
        if (angle < -180)
            angle += 360;
        Head.localEulerAngles = new Vector3(Mathf.Clamp(angle, -90, 90), 0, 0);
    }
}
