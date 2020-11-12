using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEffectManager : MonoBehaviour
{
    public GameObject[] backgroundAudioEffects;
    public GameObject[] soundEffects;

    #region Singleton
    public static AudioEffectManager Instance;
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }
    #endregion

    //효과음 오디오 재생
    public void AudioClipPlay(int audioIndex)
    {
        soundEffects[audioIndex].GetComponent<AudioSource>().Play();
    }

    //효과음 오디오 재생 중지
    public void AudioClipStop(int audioIndex)
    {
        soundEffects[audioIndex].GetComponent<AudioSource>().Stop();
    }

    //배경음 오디오 재생
    public void BackgroundAudioClipStart(int audioIndex)
    {
        backgroundAudioEffects[audioIndex].GetComponent<AudioSource>().Play();
    }


    //배경음 오디오 재생 중지
    public void BackgroundAudioClipStop(int audioIndex)
    {
        backgroundAudioEffects[audioIndex].GetComponent<AudioSource>().Stop();
    }
}
