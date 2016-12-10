using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public float Speed;

    public float RunSpeed;

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

    private Animator animator;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        Head = transform.GetChild(0).transform;
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if(direction.magnitude == 0)
        {
            animator.SetInteger("State", 0);
            //dont ask
            body.velocity = transform.TransformVector(direction) * Speed;
        }
        else if(!Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetInteger("State", 1);
            body.velocity = transform.TransformVector(direction) * Speed;
        }
        else
        {
            animator.SetInteger("State", 2);
            body.velocity = transform.TransformVector(direction) * RunSpeed;
        }
        transform.Rotate(transform.up, Rotation.x);
        float angle = Head.localRotation.eulerAngles.x + Rotation.y;
        if (angle > 180)
            angle -= 360;
        if (angle < -180)
            angle += 360;
        Head.localEulerAngles = new Vector3(Mathf.Clamp(angle, -90, 90), 0, 0);
    }

}
