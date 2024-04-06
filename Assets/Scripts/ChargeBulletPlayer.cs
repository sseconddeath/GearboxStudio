using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeBulletplayer : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 3;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        if (hitInfo.gameObject.name != "Player")
        {
            Destroy(gameObject);
        }
    }
}