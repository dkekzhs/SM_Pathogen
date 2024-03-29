﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class CharacterManager : MonoBehaviour
{
    public GameObject deathParticle;

    public Vector3[] spawnPoints;
    public string collisionName;

    public float moveSpeed; // 캐릭터의 이동속도를 설정해주는 변수입니다.
    public int healthAmount; // 캐릭터의 
    public float attackPower;

    protected Animator anim;
    protected int deadScore;
    protected IEnumerator attackCoroutine;
    protected bool isDead;

    WaitForSeconds waitTime = new WaitForSeconds(0.5f);

    protected void Awake()
    {
        isDead = false;
        attackCoroutine = Attack();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        StartCoroutine(FollowSpawnPoints());
    }

    protected void AddScore()
    {
        GameManager.Instance.score += deadScore;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals(collisionName))
        {
            moveSpeed = 0;
            StartCoroutine(attackCoroutine);
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals(collisionName))
        {
            moveSpeed = 2;
            StopCoroutine(attackCoroutine);
        }
    }

    protected IEnumerator FollowSpawnPoints()
    {
        transform.position = spawnPoints[0];
        int targetSpawnPointIndex = 1;
        Vector3 targetSpawnPoint = spawnPoints[targetSpawnPointIndex];

        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetSpawnPoint, moveSpeed * Time.deltaTime);

            if (transform.position == targetSpawnPoint)
            {
                targetSpawnPointIndex = (targetSpawnPointIndex + 1) % spawnPoints.Length;
                targetSpawnPoint = spawnPoints[targetSpawnPointIndex];
                yield return waitTime;
            }
            yield return null;
        }
    }

    protected IEnumerator Attack()
    {
        while (true)
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack") && !isDead)
            {
                anim.SetTrigger("onAttack");
                Hit(1);
            }
            yield return waitTime;
        }
    }

    protected virtual void Hit(int damage)
    {
        if (healthAmount <= 0 && !isDead)
        {
            Instantiate(deathParticle, transform.position, transform.rotation);
            Destroy(this.gameObject);
            AddScore();
            isDead = true;
        }
        healthAmount -= damage;
    }
}
