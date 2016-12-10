using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

    public Movement movement;
    public WeaponManager wm;
    public Kicker kicker;

    public Vector2 mouseSens;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        movement.Direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        movement.Rotation = new Vector2(Input.GetAxis("Mouse X") * mouseSens.x, Input.GetAxis("Mouse Y") * mouseSens.y);
        float x = Input.GetAxis("Mouse ScrollWheel");
        if (x != 0)
            wm.NextWeapon(x > 0);
        if (Input.GetKey(KeyCode.Mouse0))
            wm.Shoot();
        if (Input.GetKey(KeyCode.E))
            kicker.Kick();

    }

}
