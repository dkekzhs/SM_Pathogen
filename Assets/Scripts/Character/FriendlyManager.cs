using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyManager : CharacterManager
{
    public void DestroyGameObject()
    {
        gameObject.SetActive(false);
    }
}

