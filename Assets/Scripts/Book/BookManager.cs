using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookManager : MonoBehaviour
{
    public EncyclopediaScriptableObject encyclopediaData;
    public GameObject detailPanel;

    [Header("병원균 정보 오브젝트")]
    public Image virusImage;
    public Text virusNameText;

    [Header("병원균 내용 텍스트")]
    public Text categoryText;
    public Text troubleLocationText;
    public Text informationText;
    public Text preventiveText;

    Sprite originalSprite;

    void Start()
    {
        originalSprite = gameObject.GetComponent<Image>().sprite;
        
        SetVirusContainer();
    }

    void SetVirusContainer()
    {
        if (!encyclopediaData.isOpen)
        {
            //도감 잠금 상태
            gameObject.GetComponent<Image>().sprite = encyclopediaData.lockImage;
            gameObject.GetComponentInChildren<Text>().text = "";
        }
        else
        {
            //도감 오픈 상태
            gameObject.GetComponent<Image>().sprite = originalSprite;
            gameObject.GetComponentInChildren<Text>().text = encyclopediaData.virusName;
        }
    }

    void SetPathogenInformations()
    {
        virusNameText.text = encyclopediaData.virusName;
        virusImage.sprite = encyclopediaData.openImage;

        categoryText.text = encyclopediaData.virusCategory;
        troubleLocationText.text = encyclopediaData.virusTroubleLocation;
        preventiveText.text = encyclopediaData.virusPreventive;
        informationText.text = encyclopediaData.virusInformation;
    }

    public void OnButtonClick()
    {
        if (encyclopediaData.isOpen)
        {
            SetPathogenInformations();
            detailPanel.SetActive(!detailPanel.activeSelf);
        }
        SetVirusContainer();
    }
}
