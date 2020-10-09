using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public Vector3[] spawnPoints;
    public float tempSpeed;
    public  string collisionName;

    WaitForSeconds waitTime = new WaitForSeconds(0.5f);

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == collisionName)
        {
            Debug.Log(collisionName + " struck");
        }
    }

    protected IEnumerator FollowSpawnPoints()
    {
        transform.position = spawnPoints[0];
        int targetSpawnPointIndex = 1;
        Vector3 targetSpawnPoint = spawnPoints[targetSpawnPointIndex];

        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetSpawnPoint, tempSpeed * Time.deltaTime);

            if (transform.position == targetSpawnPoint)
            {
                targetSpawnPointIndex = (targetSpawnPointIndex + 1) % spawnPoints.Length;
                targetSpawnPoint = spawnPoints[targetSpawnPointIndex];
                yield return waitTime;
            }
            yield return null;
        }
    }
}
