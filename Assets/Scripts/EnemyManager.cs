using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : CharacterManager
{
    protected override void Hit(int damage)
    {
        if(healthAmount <= 0)
        {
            Debug.Log("Die!!!!!");
            Destroy(gameObject);
        }
        healthAmount -= damage;
        Debug.Log(collisionName + ": " + damage);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if (collision.gameObject.tag == "PlayerBullet") //총알 접촉 
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            Destroy(collision.gameObject);
            Debug.Log("총알접촉");
            Hit(1);
        }
    }
}
