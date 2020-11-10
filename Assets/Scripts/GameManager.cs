using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance;
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

    public GameObject losingScreen;
    public GameObject winningScreen;
    public int score;

    public GameObject[] prefabTroops;

    public void OnObejctButtonDown()
    {
        for(int i = 0; i < prefabTroops.Length; i++)
        {
            Instantiate(prefabTroops[i], prefabTroops[i].transform.position, Quaternion.identity);
        }
    }
}
