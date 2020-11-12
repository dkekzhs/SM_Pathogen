using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyManager : CharacterManager
{
    override protected void Hit(int damage)
    {
        if (healthAmount <= 0)
        {
            Debug.Log("Die!!!!!");
            Destroy(gameObject);
        }
        healthAmount -= damage;
        Debug.Log(collisionName + ": " + damage);
    }
}

