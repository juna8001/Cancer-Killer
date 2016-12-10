using UnityEngine;
using System.Collections;

public class Kicker : MonoBehaviour {

    public float KickWaitTime;
    public float KickTime;
    float lastKick;
    public float range, kickForce;
    public LayerMask mask;
    public int minDmg, maxDmg;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

	public void Kick()
    {
        if(Time.time - lastKick > KickWaitTime)
        {
            lastKick = Time.time;

            anim.SetTrigger("Kick");

            StartCoroutine(kicking());
        }
    }

    IEnumerator kicking()
    {
        yield return new WaitForSeconds(KickTime);

        RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.forward, range, mask);
        Debug.Log(hits.Length);
        foreach (RaycastHit hit in hits)
        {
            hit.collider.GetComponent<Enemy>().DealDmg(UnityEngine.Random.Range(minDmg, maxDmg));
            hit.collider.GetComponent<Rigidbody>().AddForce(transform.forward * kickForce, ForceMode.Acceleration);
        }
    }
}
