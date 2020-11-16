using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movePower = 1f; //움직임 속도
    public float horizontalInput; //플레이어 좌우 움직임

    public bool BulletAtt = false; // true = 총알 발사, false = 총알 발사 중지

    public int curentShotCount; //현재발사된 갯수
    public int maxShotCount; //총알 나가는거 최대갯수 
    public float power; //총알파워

    public bool shotgun; // 샷건 아이템 먹었을 때
    public int shotgunShotCount; //샷건 총알 갯수
    WaitForSeconds waitTime = new WaitForSeconds(0.1f);

    public float maxShotDelay; //총알딜레이
    public float curShotDelay; //총알 발사 딜레이

    public GameObject bulletObjA; //A총알
    public GameObject bulletObjB; //B총알

    Animator animator; //정지상태와 동작상태를 나타내주는 애니메이션

    void Start()
    {
        animator = GetComponent<Animator>();
        AudioEffectManager.Instance.BackgroundAudioClipStart(0);
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
        horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput == -1)
        {
            moveVelocity = Vector3.left;
            animator.SetBool("IsWalk", true);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (horizontalInput == 1)
        {
            moveVelocity = Vector3.right;
            animator.SetBool("IsWalk", true);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (Input.GetAxisRaw("Horizontal") == 0)
        {
            animator.SetBool("IsWalk", false);
        }
        transform.position += moveVelocity * movePower * Time.deltaTime; //moveVelocity * movePower 플레이어 움직이는 속도
    }

    void Fire()
    {
        if (curShotDelay < maxShotDelay)
            return;

        //임시 코드
        if (shotgun && BulletAtt)
        {
            StartCoroutine(ShotGun());
            return;
        }

        if (curentShotCount <= maxShotCount)
        {
            if (BulletAtt && transform.localScale == new Vector3(1, 1, 1)) //오른쪽 총알 발사
            {
                switch (power) //power case에 따라 총알 갯수 변경
                {
                    case 1:
                        GameObject bullet = Instantiate(bulletObjA, transform.position, transform.rotation); //Instantiate 총알 생성
                        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                        rigid.AddForce(Vector2.right * 10, ForceMode2D.Impulse); //오른쪽 방향으로 총알이 10속도로 일정하게 나간다.
                        break;
                    case 2:
                        GameObject bulletR = Instantiate(bulletObjA, transform.position + Vector3.up * 0.1f, transform.rotation); //총알 포지션이 위에
                        GameObject bulletL = Instantiate(bulletObjA, transform.position + Vector3.down * 0.1f, transform.rotation); //총알 포지션 아래
                        Rigidbody2D rigidR = bulletR.GetComponent<Rigidbody2D>();
                        Rigidbody2D rigidL = bulletL.GetComponent<Rigidbody2D>();
                        rigidR.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
                        rigidL.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
                        break;
                    case 3:
                        GameObject bulletRR = Instantiate(bulletObjA, transform.position + Vector3.up * 0.32f, transform.rotation);
                        GameObject bulletCC = Instantiate(bulletObjB, transform.position, transform.rotation); //bulletObjA가 아니라 bulletObjB 생성
                        GameObject bulletLL = Instantiate(bulletObjA, transform.position + Vector3.down * 0.32f, transform.rotation);
                        Rigidbody2D rigidRR = bulletRR.GetComponent<Rigidbody2D>();
                        Rigidbody2D rigidCC = bulletCC.GetComponent<Rigidbody2D>();
                        Rigidbody2D rigidLL = bulletLL.GetComponent<Rigidbody2D>();
                        rigidRR.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
                        rigidCC.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
                        rigidLL.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
                        break;
                }

                curentShotCount++; //총알이 나간 갯수
                curShotDelay = 0; 
                maxShotDelay = 0.3f; //maxShotDelay는 클릭중 나가는 총알의 갯수

                if (curentShotCount == maxShotCount) //나간 총알과 최대총알이 같을 경우 총알이 나가지않고 장전한다.
                {
                    //2초 뒤에 재장전
                    Invoke("ReloadCurrentShotCount", 2f);
                }
            }
        }

        if (curentShotCount <= maxShotCount)
        {
            if (BulletAtt && transform.localScale == new Vector3(-1, 1, 1))// 왼쪽으로 총알을 발사하는 함수
            {
                switch (power)
                {
                    case 1:
                        GameObject bullet = Instantiate(bulletObjA, transform.position, transform.rotation);
                        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                        rigid.AddForce(Vector2.left * 10, ForceMode2D.Impulse);
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
                curentShotCount++;
                curShotDelay = 0;
                maxShotDelay = 0.3f;

                if (curentShotCount == maxShotCount)
                {
                    //2초 뒤에 재장전
                    Invoke("ReloadCurrentShotCount", 2f);
                }
            }
        }
    }

    // 샷건 아이템 먹을 때 재생되는 코루틴
    IEnumerator ShotGun() //샷건 스킬 
    {
        while (true)
        {
            for (int i = 0; i < shotgunShotCount; ++i)
            {
                GameObject bullet = Instantiate(bulletObjA, transform.position, transform.rotation);
                Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                rigid.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
                yield return waitTime;
            }
            Debug.Log("샷건 기능 구현 중..");
            break;
        }
    }
    void ReloadCurrentShotCount() //샷건 스킬의 딜레이
    {
        curentShotCount = 0;
        BulletAtt = false;
    }

    void Reload() //총알장전 속도
    {
        curShotDelay += Time.deltaTime;
    }

    void PlayerHit()
    {
        //플레이어가 맞았을 경우 플레이어의 색상을 변경하는 함수
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            //플레이어가 맞았을 때
        }
    }
}
