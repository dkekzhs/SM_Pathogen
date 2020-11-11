using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOutTransition : MonoBehaviour
{
    public GameObject FadeInOutPanel;
    Color originalColor;
    WaitForSeconds waitTime = new WaitForSeconds(0.05f);

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
        //알파값 1 -> 0
        Debug.Log("FadeIn 시작!");
        StartCoroutine(FadeInEffect());
    }

    public void FadeOut()
    {
        //알파값 0 -> 1
        Debug.Log("FadeOut 시작!");
        FadeInOutPanel.SetActive(true);
        StartCoroutine(FadeOutEffect());
    }

    IEnumerator FadeInEffect()
    {
        originalColor.a = 1;
        while (true)
        {
            originalColor.a -= 0.05f;
            FadeInOutPanel.GetComponent<Image>().color = originalColor;
            if (originalColor.a <= 0)
            {
                originalColor.a = 0;
                FadeInOutPanel.GetComponent<Image>().color = originalColor;
                break;
            }
            yield return waitTime;
        }
        FadeInOutPanel.SetActive(false);
    }

    IEnumerator FadeOutEffect()
    {
        originalColor.a = 0;
        while (true)
        {
            originalColor.a += 0.05f;
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
