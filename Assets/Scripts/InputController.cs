using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

    public Movement movement;

    public Vector2 mouseSens;

    void Update()
    {
        movement.Direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        movement.Rotation = new Vector2(Input.GetAxis("Mouse X") * mouseSens.x, Input.GetAxis("Mouse Y") * mouseSens.y);
    }

}
