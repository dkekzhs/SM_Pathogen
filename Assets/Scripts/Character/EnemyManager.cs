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
           
            Destroy(collision.gameObject);
            Debug.Log("총알접촉");
            Hit(5);
        }
        if(collision.gameObject.tag == "BeeBullet")
        {
            Debug.Log("터렛 총알 맞았어요");
            Destroy(collision.gameObject);
            Hit(5);
           
        }
    }

    public void DestroyGameObject()
    {
        gameObject.SetActive(false);
    }






    

}