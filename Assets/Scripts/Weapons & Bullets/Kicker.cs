using UnityEngine;
using System.Collections;

public class Kicker : MonoBehaviour {

    public float KickWaitTime;
    public float KickTime;
    float lastKick;
    public float range, kickForce;
    public LayerMask mask;
    public int minDmg, maxDmg;

    [SerializeField]
    private GameObject bloodSplash;

    private AudioSource audioSource;

    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
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
            audioSource.Play();
            hit.collider.GetComponent<Enemy>().DealDmg(UnityEngine.Random.Range(minDmg, maxDmg));
            hit.collider.GetComponent<Rigidbody>().AddForce(transform.forward * kickForce, ForceMode.Acceleration);
            GameObject temp = (GameObject)Instantiate(bloodSplash, hit.point, new Quaternion());
            temp.GetComponent<ParticleSystem>().Play();
        }
    }
}
