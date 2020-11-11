using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClickManager : MonoBehaviour
{
    public IntroSayManager introSayManager;
    public GameObject interactionPanel;

    void Update()
    {
        if (GameManager.Instance.isInteraction)
        {
            interactionPanel.SetActive(true);
        }
        else
        {
            interactionPanel.SetActive(false);
        }
    }

    public void OnPlayerClicked()
    {
        if (GameManager.Instance.isInteraction)
        {
            introSayManager.SetText();
        }
    }
}
