using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    float jumpForce = 6000f;
    float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        rb.MovePosition(rb.position + Vector2.right * moveX * speed * Time.deltaTime);  //или transform.position?
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.AddForce(Vector2.up * jumpForce);
            //rb.AddForce(new Vector2 (0, jumpForce), ForceMode2D.Impulse);
        }
    }
}
