using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class CharacterManager : MonoBehaviour
{
    public Vector3[] spawnPoints;
    public  string collisionName;

    public float moveSpeed;
    public int healthAmount;
    public float attackSpeed;

    protected IEnumerator attackCoroutine;
    GameObject collisionGameobject;

    WaitForSeconds waitTime = new WaitForSeconds(0.5f);

    protected void Awake()
    {
        attackCoroutine = Attack();
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == collisionName)
        {
            Debug.Log(collisionName + " struck");
            collisionGameobject = collision.gameObject;
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
            Debug.Log("Attack!! " + collisionName);
            Hit(1);
            yield return waitTime;
        }
    }

    abstract protected void Hit(int damage);
}
