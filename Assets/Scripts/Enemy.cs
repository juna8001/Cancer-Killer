using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public void DealDmg(int dmg)
    {
        Debug.Log(name + " get dmg: " + dmg);
    }
}
