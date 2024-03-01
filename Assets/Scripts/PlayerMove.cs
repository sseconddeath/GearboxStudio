using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
   public float jumpForce = 15f;
    float speed = 10f;
    private Vector2 moveVector;
    //private bool facingRight = true;
    private Animator anim;
    public SpriteRenderer sr;
    public bool onGround;
    public Transform GroundCheck;
    public float checkRadius = 0.5f;
    public LayerMask Ground;
    
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
       
        Walk();
        Jump();
        Flip();
        CheckingGround();
       




    }
    void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);
        anim.SetBool("onGround", onGround);

    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& onGround)
        {
            
            rb.AddForce(Vector2.up * jumpForce);
        }

    }



    void Walk()//ходьба
    {
        moveVector.x = Input.GetAxis("Horizontal");
        anim.SetFloat("moveX", Mathf.Abs(moveVector.x));
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
    }
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
    //[System.Obsolete]
    //void LoadScene()
    //{
    //    Application.LoadLevel(Application.loadedLevel);

    //}
    //private void OnTriggerEnter2D(Collider2D coll)
    //{
    //    if (coll.tag == "enemy")
    //        gameObject.SetActive(false);
    //    Invoke("LoadScene", 1.5f);
    //    LoadScene();
    //}
}
