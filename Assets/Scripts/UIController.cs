using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {

    public WeaponManager wp;

    public Text text;

    void Update()
    {
        text.text = wp.getWeapon().getAmmo() + " / " + wp.getWeapon().maxAmmo();
    }
}
