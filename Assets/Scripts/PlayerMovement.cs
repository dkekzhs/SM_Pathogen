using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movePower = 1f; //움직임 속도
    public bool LeftMove = false;
    public bool RightMove = false; //좌우 움직임



    public bool BulletAtt = false; //총알발사

    public int maxShot;    //현재발사된 갯수
    public int maxShot2; //총알 나가는거 최대갯수
    public float power ; //총알파워
    public float maxShotDelay; //총알딜레이
    public float curShotDelay; //총알 발사 딜레이

    public GameObject bulletObjA; //A총알
    public GameObject bulletObjB; //B총알
    Rigidbody2D rigid;
    Vector3 movement;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        move();
        Fire();
        Reload();
    }
    void move()
    {
        Vector3 moveVelocity = Vector3.zero;
        if(LeftMove ==true)
        {
            moveVelocity = Vector3.left;
            animator.SetBool("IsWalk", true);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (RightMove==true)
        {
            moveVelocity = Vector3.right;
            animator.SetBool("IsWalk", true);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (Input.GetAxisRaw("Horizontal") == 0)
        {
            animator.SetBool("IsWalk", false);
        }
            transform.position += moveVelocity * movePower * Time.deltaTime;
    }

    void Fire()
    {       
        if (curShotDelay < maxShotDelay)
            return;
        if (maxShot <= maxShot2) { 
        if (BulletAtt == true && transform.localScale == new Vector3(1, 1, 1)) {
            switch (power)
            {
                case 1:
                    { 
                        GameObject bullet = Instantiate(bulletObjA, transform.position, transform.rotation);
                        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                        rigid.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
                       

                    }

                    break;
                case 2:
                    GameObject bulletR = Instantiate(bulletObjA, transform.position + Vector3.up * 0.1f, transform.rotation);
                    GameObject bulletL = Instantiate(bulletObjA, transform.position + Vector3.down * 0.1f, transform.rotation);
                    Rigidbody2D rigidR = bulletR.GetComponent<Rigidbody2D>();
                    Rigidbody2D rigidL = bulletL.GetComponent<Rigidbody2D>();
                    rigidR.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
                    rigidL.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
                  
                    break;
                case 3:
                    GameObject bulletRR = Instantiate(bulletObjA, transform.position + Vector3.up * 0.32f, transform.rotation);
                    GameObject bulletCC = Instantiate(bulletObjB, transform.position, transform.rotation);
                    GameObject bulletLL = Instantiate(bulletObjA, transform.position + Vector3.down * 0.32f, transform.rotation);
                    Rigidbody2D rigidRR = bulletRR.GetComponent<Rigidbody2D>();
                    Rigidbody2D rigidCC = bulletCC.GetComponent<Rigidbody2D>();
                    Rigidbody2D rigidLL = bulletLL.GetComponent<Rigidbody2D>();
                    rigidRR.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
                    rigidCC.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
                    rigidLL.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
                   
                    break;
            }
                maxShot++;
                curShotDelay = 0;
                maxShotDelay = 0.3f;
                if (maxShot == maxShot2)
                {
                    maxShot = 0;
                    BulletAtt = false;
                }
            }
        }
        if (maxShot <= maxShot2)
        {
            if (BulletAtt == true && transform.localScale == new Vector3(-1, 1, 1))
            {
                switch (power)
                {
                    case 1:
                        {
                            GameObject bullet = Instantiate(bulletObjA, transform.position, transform.rotation);
                            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                            rigid.AddForce(Vector2.left * 10, ForceMode2D.Impulse);


                        }

                        break;
                    case 2:
                        GameObject bulletR = Instantiate(bulletObjA, transform.position + Vector3.up * 0.1f, transform.rotation);
                        GameObject bulletL = Instantiate(bulletObjA, transform.position + Vector3.down * 0.1f, transform.rotation);
                        Rigidbody2D rigidR = bulletR.GetComponent<Rigidbody2D>();
                        Rigidbody2D rigidL = bulletL.GetComponent<Rigidbody2D>();
                        rigidR.AddForce(Vector2.left * 10, ForceMode2D.Impulse);
                        rigidL.AddForce(Vector2.left * 10, ForceMode2D.Impulse);

                        break;
                    case 3:
                        GameObject bulletRR = Instantiate(bulletObjA, transform.position + Vector3.up * 0.32f, transform.rotation);
                        GameObject bulletCC = Instantiate(bulletObjB, transform.position, transform.rotation);
                        GameObject bulletLL = Instantiate(bulletObjA, transform.position + Vector3.down * 0.32f, transform.rotation);
                        Rigidbody2D rigidRR = bulletRR.GetComponent<Rigidbody2D>();
                        Rigidbody2D rigidCC = bulletCC.GetComponent<Rigidbody2D>();
                        Rigidbody2D rigidLL = bulletLL.GetComponent<Rigidbody2D>();
                        rigidRR.AddForce(Vector2.left * 10, ForceMode2D.Impulse);
                        rigidCC.AddForce(Vector2.left * 10, ForceMode2D.Impulse);
                        rigidLL.AddForce(Vector2.left * 10, ForceMode2D.Impulse);

                        break;
                }
                maxShot++;
                curShotDelay = 0;
                maxShotDelay = 0.3f;
                if (maxShot == maxShot2)
                {
                    maxShot = 0;
                    BulletAtt = false;
                }
            }
        }
        }
    void Reload()
    {
       curShotDelay += Time.deltaTime;
    }
}
