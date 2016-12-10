using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {

    public WeaponManager wp;
    public PlayerHealth hp;

    public Text ammoText, hpText;

    void Update()
    {
        ammoText.text = wp.getWeapon().getAmmo() + " / " + wp.getWeapon().maxAmmo();
        hpText.text = hp.hp.ToString();
    }
}
