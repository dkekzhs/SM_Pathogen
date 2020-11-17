using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{

    public List<GameObject> enemiesInRange;
    public string collisionName;
    protected Animator anim;

    public float speed = 1f; //총알이 얼마나 빠른지
    public float maxShotDelay; //총알딜레이
    public float curShotDelay; //총알 발사 딜레이

    public Vector3 startPosition; //총알 시작지점 
    public Vector3 targetPosition; // 도착지점
    Vector3 TargetStartDistance; //시작거리와 타겟거리 사이

  
    public GameObject Target; // 타겟 
    public GameObject BeeShotPos;


    public GameObject BeeBullet;

    // Start is called before the first frame update
    void Start()
    {
        enemiesInRange = new List<GameObject>();
        anim = GetComponent<Animator>();
        anim.SetBool("Stay", false);
        DestoryBee();
    }

    // Update is called once per frame
    void Update()
    {
        FireBullet();
        Reload();

    }
    void OnEnemyDestroy(GameObject Enemy)
    {
        //적이 제거되면 리스트에서 제거합니다. 
        enemiesInRange.Remove(Enemy);
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals(collisionName))
        {

            Debug.Log("찾았다 애너미");
            anim.SetBool("Stay", true);
            enemiesInRange.Add(collision.gameObject);
            Target = enemiesInRange[0];


        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        //충돌이 마지막 지점에 다달았을 경우
        if (collision.tag.Equals(collisionName))
        {
            Debug.Log("사라졌다 애너미");
            anim.SetBool("Stay", false);
            enemiesInRange.Remove(collision.gameObject);
            if (enemiesInRange.Count != 0)
            {
                CloseEnemy();
            }
            else Target = null;

        }
    }
    void FireBullet() //총알 발사
    {
        if (curShotDelay < maxShotDelay)
            return;
        if (Target != null)
        {

            
            startPosition = BeeShotPos.transform.position;   //총알시작지점
            targetPosition = Target.transform.position; //타켓 위치
            TargetStartDistance = targetPosition - startPosition;

            GameObject bullet = Instantiate(BeeBullet, startPosition, transform.rotation); //총알 오브젝트 생성
            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();  //총알 바디
            rigid.AddForce(TargetStartDistance * speed, ForceMode2D.Impulse);


            curShotDelay = 0; //총알 딜레이 추가
            maxShotDelay = 0.8f; //maxshotdelay로 총알 딜레이 추가
        }

    }
    void Reload() //총알장전 속도
    {
        curShotDelay += Time.deltaTime;
    }

    public void CloseEnemy() //가까운 적 떄리기
    {
        float maxDistance = 100f ;
 
        int selectedIndex = -1;
        for (int i = 0; i < enemiesInRange.Count; i++)
        {
            float curDist = Vector3.Distance(enemiesInRange[i].transform.position, startPosition);
            if (maxDistance > curDist)
            {
                maxDistance = curDist;
                selectedIndex = i;
                Target = enemiesInRange[i];
            }

        }
    }
    void DestoryBee()
    {
        Destroy(gameObject, 5f);
    }
}