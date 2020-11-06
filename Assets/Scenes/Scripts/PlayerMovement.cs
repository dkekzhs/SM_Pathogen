using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movePower = 1f; //움직임 속도
    public bool LeftMove = false;
    public bool RightMove = false; //좌우 움직임

    public int bulletCnt = 0;

    public bool BulletAtt = false; //총알발사

    public float speed; //총알스피드
    public float power; //총알파워
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
        if (BulletAtt == true && transform.localScale == new Vector3(1, 1, 1)) {
            switch (power)
            {
                case 1:
                    { 
                        GameObject bullet = Instantiate(bulletObjA, transform.position, transform.rotation);
                        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                        rigid.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
                        curShotDelay = 0;
                        bulletCnt++;
                        if(bulletCnt == 5)
                        {
                            BulletAtt = false;
                            bulletCnt = 0;
                        }
                    }

                    break;
                case 2:
                    GameObject bulletR = Instantiate(bulletObjA, transform.position + Vector3.up * 0.1f, transform.rotation);
                    GameObject bulletL = Instantiate(bulletObjA, transform.position + Vector3.down * 0.1f, transform.rotation);
                    Rigidbody2D rigidR = bulletR.GetComponent<Rigidbody2D>();
                    Rigidbody2D rigidL = bulletL.GetComponent<Rigidbody2D>();
                    rigidR.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
                    rigidL.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
                    curShotDelay = 0;
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
                    curShotDelay = 0;
                    break;
            }
        }

    }
    void Reload()
    {
       curShotDelay += Time.deltaTime;
    }
}
