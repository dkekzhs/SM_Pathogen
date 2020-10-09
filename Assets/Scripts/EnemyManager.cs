using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : CharacterManager
{
    void Start()
    {
        StartCoroutine(FollowSpawnPoints());
    }
}
