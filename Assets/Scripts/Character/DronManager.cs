using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronManager : CharacterManager
{
    public bool BulletAtt = false; // true = 총알 발사, false = 총알 발사 중지

    public int curentShotCount; //현재발사된 갯수
    public int maxShotCount; //총알 나가는거 최대갯수 
    public float power; //총알파워
    public float maxShotDelay; //총알딜레이
    public float curShotDelay; //총알 발사 딜레이

    public GameObject DronBullet;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BorderBullet")
        {
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {       
        FireBullet();
        Reload();
    }
    void FireBullet() //총알 발사
    {
        if (curShotDelay < maxShotDelay)
            return;

        if (curentShotCount <= maxShotCount)
        {
          
                GameObject bullet = Instantiate(DronBullet, transform.position, transform.rotation); //총알 오브젝트 생성
                Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();  //총알 바디
                rigid.AddForce(Vector2.down * 10, ForceMode2D.Impulse);

            curentShotCount++;
            curShotDelay = 0.9f;
          

        }
    }
    void Reload() //총알장전 속도
    {
        curShotDelay += Time.deltaTime;
    }
    public void DestroyGameObject()
    {
        gameObject.SetActive(false);
    }
}
