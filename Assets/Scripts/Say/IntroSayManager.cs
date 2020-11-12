using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroSayManager : MonoBehaviour
{
    protected int sayId;
    protected int sayActionIndex;
    protected List<Say[]> listSay;

    WaitForSeconds waitTime = new WaitForSeconds(0.1f);

    [Header("대화 창 오브젝트")]
    public Text questionText;

    void Start()
    {
        GameManager.Instance.isInteraction = true;
        listSay = new List<Say[]>();
        GenerateSayData();
    }

    void GenerateSayData()
    {
        listSay.Add(new Say[] { 
            new Say("2020년 어느날 오후 3시"),
            new Say("어질러진 방안에는"),
            new Say("3년된 쓰레기가 날라다닌다."),
            new Say("주인공은 방안에서 배달음식만"),
            new Say("시켜먹으면서 운동도 하지 않는다."),
            new Say("어느새 주인공의 몸무게는 "),
            new Say("100..150..200kg.. 계속 증가하고.."),
            new Say("다음 날 주인공은 지속된 건강악화로 "),
            new Say("쓰레기 더미 방에 쓰러지게된다.."),
            new Say(EnumManager.States.NextScene)});
    }

    public void SetText()
    {
        InitialValueSetting();

        if(listSay[sayId][sayActionIndex].state == EnumManager.States.NextScene)
        {
            //다음씬으로 넘어가는 대사입니다.
            ScreenManager.instance.NextScene(1f);
            return;
        }

        StartCoroutine(TypingQuestion());
    }

    void NextSay()
    {
        sayActionIndex++;
        if(sayActionIndex >= listSay[sayId].Length)
        {
            sayId++;
            sayActionIndex = 0;

            if(sayId == listSay.Count)
            {
                //대화 데이터의 끝에 도달했을 경우
                Debug.Log("대화 끝");
            }
        }
    }

    void InitialValueSetting()
    {
        questionText.text = "";
    }

    IEnumerator TypingQuestion()
    {
        AudioEffectManager.Instance.AudioClipPlay(0);
        GameManager.Instance.isInteraction = false;
        for(int i = 0; i <listSay[sayId][sayActionIndex].question.Length; ++i)
        {
            questionText.text += listSay[sayId][sayActionIndex].question[i];
            yield return waitTime;
        }
        GameManager.Instance.isInteraction = true;
        AudioEffectManager.Instance.AudioClipStop(0);
        NextSay();
    }
}
