using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    [SerializeField]
    protected float speed = 7f;
    [SerializeField]
    protected int hp = 3;
    protected Rigidbody body;
    protected Animator animator;

    void Awake()
    {
        body = GetComponent<Rigidbody>();
        hp = Random.Range(1,4);
        animator = GetComponent<Animator>();
        animator.SetFloat("Multiplayer", Random.Range(0.8f, 1.2f));
    }

    protected virtual void Update()
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
        animator.SetTrigger("Death");
        SpriteRotator rotator = GetComponentInChildren<SpriteRotator>();
        rotator.enabled = false;
        rotator.gameObject.transform.rotation = Quaternion.Euler(0,rotator.gameObject.transform.rotation.eulerAngles.y,0);
        this.enabled = false;
    }
}
