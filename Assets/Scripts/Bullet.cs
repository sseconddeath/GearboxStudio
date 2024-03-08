using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float moveSpeed = 7f;
    Rigidbody2D rb;
    PlayerMove target;
    public float timeDestroy = 3f;
    Vector2 moveDirection;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<PlayerMove>();
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, 0/*moveDirection.y*/);
        Destroy(gameObject, 3f);
        Invoke("DestroyBullet",timeDestroy);
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
        }
    }


}
