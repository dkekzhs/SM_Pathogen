using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : CharacterManager
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if (collision.gameObject.tag == "PlayerBullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            Destroy(collision.gameObject);
            Debug.Log("총알접촉");
            Hit(1);
        }
    }

    public void DestroyGameObject()
    {
        gameObject.SetActive(false);
    }
}