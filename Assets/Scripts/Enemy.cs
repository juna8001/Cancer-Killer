using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    [SerializeField]
    private float speed = 7f;
    [SerializeField]
    private int hp = 3;
    [SerializeField]
    private AudioClip [] shouts;
    private Rigidbody body;
    private Animator animator;
    private AudioSource audioSource;

    void Awake()
    {
        body = GetComponent<Rigidbody>();
        hp = Random.Range(1,4);
        animator = GetComponent<Animator>();
        animator.SetFloat("Multiplayer", Random.Range(0.8f, 1.2f));
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        body.AddForce((transform.position - Camera.main.transform.position).normalized * speed * Time.deltaTime);
    }

	public void DealDmg(int dmg)
    {
        Debug.Log(name + " get dmg: " + dmg);
        hp -= dmg;
        if(hp<=0)
        {
            Die();
        }
    }

    void Die()
    {
        audioSource.clip = shouts[Random.Range(0, shouts.Length)];
        audioSource.Play();
        animator.SetTrigger("Death");
        SpriteRotator rotator = GetComponentInChildren<SpriteRotator>();
        rotator.enabled = false;
        rotator.gameObject.transform.rotation = Quaternion.Euler(0,rotator.gameObject.transform.rotation.eulerAngles.y,0);
        this.enabled = false;
    }
}
