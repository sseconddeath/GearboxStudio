using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    float jumpForce = 700f;
    float speed = 10f;
    private Vector2 moveVector;
    //private bool facingRight = true;
    private Animator anim;
    public SpriteRenderer sr;
    //private States State
    //{

    //    get { return (States)anim.GetInteger("state"); }
    //    set { anim.SetInteger("state",(int) value);}
    //}

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        anim = GetComponent<Animator>();
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
        //rb.position + moveVector * speed * Time.deltaTime;
       // Walk();
        Flip();

        //float moveX = Input.GetAxis("Horizontal");
        //rb.MovePosition(rb.position + Vector2.right * moveX * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.AddForce(Vector2.up * jumpForce);
            //rb.AddForce(new Vector2 (0, jumpForce), ForceMode2D.Impulse);
        }




    }


    public enum States
    {
        playerstate,
       run,
        jump

    }
    //void Walk()
    //{
    //    moveVector.x = Input.GetAxis("Horizontal");
    //    anim.SetFloat("moveX", Mathf.Abs(moveVector.x));
    //     rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
    //}
    void Flip() //поворот персонажа
    {
        if ( moveVector.x > 0)
        {
            sr.flipX = false;
        }
        else if( moveVector.x < 0)
        {
            sr.flipX = true;
        }


    }
}
