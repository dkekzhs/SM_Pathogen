﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DronSkillBtn : MonoBehaviour
{
    public Image SkillFitter; //스킬이 차는 검은색 이미지
    public float coolTime; //쿨타임 변수

    public Vector3 RandomSpawn;
    public GameObject Dron;

    void start()
    {
        SkillFitter.fillAmount = 0; //0이면 투명한 상태


    }

    public void UseSkill() //스킬사용
    {
        if (SkillFitter.fillAmount == 0)
        {
            Debug.Log("스킬 사용");
            SkillFitter.fillAmount = 1;
            StartCoroutine("CoolTime");
            SpawnDron();




        }

    }


    IEnumerator CoolTime() //쿨타임 
    {
        while (SkillFitter.fillAmount > 0)
        {
            SkillFitter.fillAmount -= 1 * Time.smoothDeltaTime / coolTime;
            yield return null;
        }
        yield break;
    }

    void SpawnDron()
    {
        int randomX = Random.Range(-6, 2);
        float randomY = Random.Range(1f, 3f);
        RandomSpawn = new Vector3(randomX, randomY, 0);
        Instantiate(Dron, RandomSpawn, transform.rotation);

    }
}
