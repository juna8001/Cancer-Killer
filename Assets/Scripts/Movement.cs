using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public static Transform PlayerTransform;

    public float Speed;

    public float RunSpeed;
    [SerializeField]
    private float maxVelocityChange = 10.0f;

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

    public Animator animator;

    void Start()
    {
        PlayerTransform = transform;
        body = GetComponent<Rigidbody>();
        Head = transform.GetChild(0).transform;
        animator = GetComponent<Animator>(); 
    }

    void FixedUpdate()
    {
        if(direction.magnitude == 0)
        {
            animator.SetInteger("State", 0);

            Move(0);
        }
        else if(!Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetInteger("State", 1);

            Move(Speed);
        }
        else
        {
            animator.SetInteger("State", 2);

            Move(RunSpeed);
        }
        transform.Rotate(transform.up, Rotation.x);
        float angle = Head.localRotation.eulerAngles.x + Rotation.y;
        if (angle > 180)
            angle -= 360;
        if (angle < -180)
            angle += 360;
        Head.localEulerAngles = new Vector3(Mathf.Clamp(angle, -90, 90), 0, 0);
    }

    void Move(float speed)
    {

            Vector3 targetVelocity = new Vector3(direction.x, 0, direction.z);
	        targetVelocity = transform.TransformDirection(targetVelocity);
	        targetVelocity *= speed;
 
	        // Apply a force that attempts to reach our target velocity
	        Vector3 velocity = body.velocity;
	        Vector3 velocityChange = (targetVelocity - velocity);
	        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
	        velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
	        velocityChange.y = 0;
	        body.AddForce(velocityChange, ForceMode.VelocityChange);
    }

}
