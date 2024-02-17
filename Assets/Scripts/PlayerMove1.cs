using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    float jumpForce = 700f;
    float speed = 10f;
    private Vector2 moveVector;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
        //rb.position + moveVector * speed * Time.deltaTime;


        //float moveX = Input.GetAxis("Horizontal");
        //rb.MovePosition(rb.position + Vector2.right * moveX * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.AddForce(Vector2.up * jumpForce);
            //rb.AddForce(new Vector2 (0, jumpForce), ForceMode2D.Impulse);
        }
    }
}
