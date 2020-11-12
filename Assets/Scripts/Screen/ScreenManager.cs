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

    IEnumerator AwaitLoadScene(float delayTime) //allowSceneActivation는 장면이 준비된 즉시 장면이 활성화되는 것을 허용합니다.
    {
        yield return null;
        asyncOperation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        asyncOperation.allowSceneActivation = false; //false는 다음Sence으로 넘어가지 않게 해줍니다.

        while (!asyncOperation.isDone) //isDone이 true가 되기 전까지 while문을 반복해줍니다.
        {
            yield return null;
            if (asyncOperation.progress >= 0.9f) //반복 중에 진행이 90% 이상 완료가 되면 allowSceneActivation값을 true로 바꿔줍니다.
            {
                yield return new WaitForSeconds(delayTime);
                asyncOperation.allowSceneActivation = true;
                break;
            }
        }
    }
}
