using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public AudioSource LazerAudio;
    public Transform firepoint;
    public GameObject bullet;
    private bool facingRight = true;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) facingRight = false;
        if (Input.GetKeyDown(KeyCode.RightArrow)) facingRight = true;
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            
            Shoot();
            LazerAudio.Play();
        }
    }
    void Shoot()
    {
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            firepoint.rotation = Quaternion.Euler(0, 0, 45);
            Instantiate(bullet, firepoint.position, firepoint.rotation);
        }
        else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            firepoint.rotation = Quaternion.Euler(0, 0, 135);
            Instantiate(bullet, firepoint.position, firepoint.rotation);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            firepoint.rotation = Quaternion.Euler(0, 0, 90);
            Instantiate(bullet, firepoint.position, firepoint.rotation);
        }
        else if(Input.GetKey(KeyCode.LeftArrow)||facingRight==false)
        {
            firepoint.rotation = Quaternion.Euler(0, 0, 180);
            Instantiate(bullet, firepoint.position, firepoint.rotation);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || facingRight == true)
        {
            firepoint.rotation = Quaternion.Euler(0, 0, 0);
            Instantiate(bullet, firepoint.position, firepoint.rotation);
        }
    }
}
