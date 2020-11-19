using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Text scoreText;
    public Text stageText;
    public bool isInteraction;

    public int score;
    public int stage;

    bool isGameOver;
    bool isNextStage;

    float currentStageTime;
    float nextStageTime;
    
    void Start()
    {
        nextStageTime = 2;
        isGameOver = false;
        isNextStage = false;
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

        SetScoreAndStageText();
        StartStage();
    }

    void SetScoreAndStageText()
    {
        scoreText.text = string.Format("{0:#,###}", score);
        stageText.text = string.Format("{0}탄", stage);
    }

    void StartStage()
    {
        currentStageTime += Time.deltaTime;

        if (currentStageTime < nextStageTime)
        {
            isNextStage = true;
            return;
        }

        if (isNextStage)
        {
            Spawner.Instance.OnSpawnEnemy();
            stage++;
            nextStageTime += stage;
            isNextStage = false;
            currentStageTime = 0;
        }
    }

    public void GameOver()
    {
        GameOverScreen.SetActive(true);
        isGameOver = true;
    }
}
