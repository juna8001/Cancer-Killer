using UnityEngine;
using System.Collections;

public class WeaponManager : MonoBehaviour {

    Animator animator;

    public float ChangeWeaponTime;
    public GameObject[] weaponsGO;
    public IWeapon[] weapons;

    Coroutine changeWeaponCoroutine;

    void Start()
    {
        animator = GetComponent<Animator>();
        weapons = new IWeapon[weaponsGO.Length];
        for (int i = 0; i < weaponsGO.Length; i++)
            weapons[i] = weaponsGO[i].GetComponent<IWeapon>();

        currentWeapon = 0;
        ChangeWeapon(0);
    }

    [SerializeField]
    int currentWeapon;

    public void NextWeapon(bool rev)
    {
        int x = (rev ? currentWeapon + 1 : currentWeapon - 1) % weapons.Length;
        if (x < 0)
            x += weapons.Length;
        ChangeWeapon(x);
    }

    public void ChangeWeapon(int index) {
        if(index != currentWeapon)
        {
            if (changeWeaponCoroutine != null)
                StopCoroutine(changeWeaponCoroutine);
            animator.SetTrigger("Change");
            changeWeaponCoroutine = StartCoroutine(Change(index));
        }
    }

    IEnumerator Change(int next)
    {
        if(changeWeaponCoroutine == null) {
            yield return new WaitForSeconds(ChangeWeaponTime / 2);
            weapons[currentWeapon].SetChoosen(false);
            currentWeapon = next;
            weapons[currentWeapon].SetChoosen(true);
            yield return new WaitForSeconds(ChangeWeaponTime / 2);
            changeWeaponCoroutine = null;
        }
    }

    public void Shoot()
    {
        if (changeWeaponCoroutine == null)
            weapons[currentWeapon].Shoot();
    }

    public IWeapon getWeapon()
    {
        return weapons[currentWeapon];
    }

}
