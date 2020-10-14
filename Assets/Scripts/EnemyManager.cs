using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : CharacterManager
{
    Animator anim;
    void Awake()
    {
        base.Awake();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        StartCoroutine(FollowSpawnPoints());
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.tag.Equals(collisionName))
        {
            moveSpeed = 0;
            Debug.Log("Coroutine Start!");
            StartCoroutine(attackCoroutine);
            anim.SetBool("isWalk", false);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals(collisionName))
        {
            moveSpeed = 2;
            Debug.Log("Coroutine Stop!");
            StopCoroutine(attackCoroutine);
            anim.SetBool("isWalk", true);
        }
    }

    override protected void Hit(int damage)
    {
        if(healthAmount <= 0)
        {
            Debug.Log("Die!!!!!");
            Destroy(gameObject);
        }
        healthAmount -= damage;
        Debug.Log(collisionName + ": " + damage);
    }
}
