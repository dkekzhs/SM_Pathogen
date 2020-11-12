using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleManager : MonoBehaviour
{
    public string collisionName;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals(collisionName))
        {
            GameManager.Instance.GameOver();
        }
    }

}
