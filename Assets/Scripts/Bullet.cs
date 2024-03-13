using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _damage;


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

    public float Damage => _damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Healt healt = other.GetComponent<Healt>();
        if (other.gameObject.name == "Player")
        {
            healt.GetDamage(_damage);
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "ground")
        {
            Destroy(gameObject);
        }

    }


}
