using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class Shell : MonoBehaviour {

    public AudioClip clip;

    protected virtual void OnCollisionEnter(Collision collision)
    {
        AudioSource source = GetComponent<AudioSource>();
        source.clip = clip;
        source.Play();
        StartCoroutine(destroyer(4));
    }

    IEnumerator destroyer(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

}
