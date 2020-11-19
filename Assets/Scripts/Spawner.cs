using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region Singleton
    public static Spawner Instance;
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion

    public GameObject[] enemyPrefabs;

    WaitForSeconds waitTime = new WaitForSeconds(0.5f);

    public void OnSpawnEnemy()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            for (int i = 0; i < GameManager.Instance.stage * 2; ++i)
            {
                Instantiate(enemyPrefabs[0], transform.position, Quaternion.identity);
                yield return waitTime;
            }
            break;
        }
    }
}
