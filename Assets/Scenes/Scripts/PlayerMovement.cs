using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movePower = 1f;
    public bool LeftMove = false;
    public bool RightMove = false;
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
}
