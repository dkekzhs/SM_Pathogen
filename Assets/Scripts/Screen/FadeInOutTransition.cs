using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOutTransition : MonoBehaviour
{
    public GameObject FadeInOutPanel; //화면이 전환될 때 적용되는 이벤트입니다.
    Color originalColor;
    WaitForSeconds waitTime = new WaitForSeconds(0.05f); //타이핑 속도

    #region Singleton
    public static FadeInOutTransition instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    #endregion

    void Start()
    {
        FadeIn();
        originalColor = FadeInOutPanel.GetComponent<Image>().color; 
    }

    public void FadeIn()
    {
        //알파값 1 -> 0 화면을 서서히 밝게 해주는 함수입니다.
        Debug.Log("FadeIn 시작!");
        StartCoroutine(FadeInEffect());
    }

    public void FadeOut()
    {
        //알파값 0 -> 1 화면을 서서히 어둡게 해주는 함수입니다.
        Debug.Log("FadeOut 시작!");
        FadeInOutPanel.SetActive(true); //GameObject FadeInOutPanel을 활성화 시켜줍니다.
        StartCoroutine(FadeOutEffect());
    }

    IEnumerator FadeInEffect()
    {
        originalColor.a = 1;
        while (true)
        {
            originalColor.a -= 0.05f; //0.05f속도로 빼주면서 originalColor를 빼주는 이벤트입니다.
            FadeInOutPanel.GetComponent<Image>().color = originalColor;
            if (originalColor.a <= 0)
            {
                originalColor.a = 0;
                FadeInOutPanel.GetComponent<Image>().color = originalColor;
                break;
            }
            yield return waitTime;
        }
        FadeInOutPanel.SetActive(false); //GameObject FadeInOutPanel을 비활성화 시켜줍니다.
    }

    IEnumerator FadeOutEffect()
    {
        originalColor.a = 0;
        while (true)
        {
            originalColor.a += 0.05f; //0.05f속도로 더해주면서 originalColor를 더해주는 이벤트
            if (originalColor.a >= 1)
            {
                originalColor.a = 1;
                FadeInOutPanel.GetComponent<Image>().color = originalColor;
                break;
            }
            FadeInOutPanel.GetComponent<Image>().color = originalColor;
            yield return waitTime;
        }
    }
}
