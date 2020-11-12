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

    public GameObject GameOverScreen;
    public bool isInteraction;
    public int score;
    public GameObject[] prefabTroops;

    bool isGameOver;
    
    void Start()
    {
        isGameOver = false;
    }

    void Update()
    {
        if (isGameOver)
        {
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.Z))
            {
                ScreenManager.instance.RestartScene();
                Time.timeScale = 1;
            }
        }
    }

    public void OnObjectButtonDown()
    {
        for(int i = 0; i < prefabTroops.Length; i++)
        {
            Instantiate(prefabTroops[i], prefabTroops[i].transform.position, Quaternion.identity);
        }
    }

    public void GameOver()
    {
        GameOverScreen.SetActive(true);
        isGameOver = true;
    }
}
