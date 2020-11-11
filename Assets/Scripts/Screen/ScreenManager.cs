using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    #region Singleton
    public static ScreenManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }
    #endregion

    AsyncOperation asyncOperation;

    public void NextScene(float delayTime)
    {
        FadeInOutTransition.instance.FadeOut();
        StartCoroutine(AwaitLoadScene(delayTime));
    }

    IEnumerator AwaitLoadScene(float delayTime)
    {
        yield return null;
        asyncOperation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)
        {
            yield return null;
            if (asyncOperation.progress >= 0.9f)
            {
                yield return new WaitForSeconds(delayTime);
                asyncOperation.allowSceneActivation = true;
                break;
            }
        }
    }
}
