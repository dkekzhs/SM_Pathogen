using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public int health;
    public Sprite[] sprites;

    SpriteRenderer SpriteRenderer;
    Rigidbody2D rigid;

    private void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.down * speed;
    }

    void OnHit(int dmg)
    {
        health -= dmg;
        SpriteRenderer.sprite = sprites[1];
        Invoke("ReturnSprite", 0.1f);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void ReturnSprite()
    {
        SpriteRenderer.sprite = sprites[0];
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BorderBullet")
            Destroy(gameObject);
        else if (collision.gameObject.tag == "PlayerBullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            OnHit(bullet.dmg);

            Destroy(collision.gameObject);
        }
    }
}