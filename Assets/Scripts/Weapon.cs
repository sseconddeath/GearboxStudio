using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public AudioSource LazerAudio;
    public Transform firepoint;
    public GameObject bullet;
    public GameObject chargeBullet;
    public float timer = 1;
    private bool facingRight = true;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) facingRight = false;
        if (Input.GetKeyDown(KeyCode.RightArrow)) facingRight = true;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (timer > 0) timer -= Time.deltaTime;
            if (timer < 0) timer = 0;
        }


        if (Input.GetKeyUp(KeyCode.LeftShift))
        {  
            if (timer <= 0)
            {
                timer = 1;
                ChargeShoot();
                LazerAudio.Play();
            }
            else 
            {          
                timer = 1;
                Shoot();
                LazerAudio.Play();
            }
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
    void ChargeShoot()
    {
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            firepoint.rotation = Quaternion.Euler(0, 0, 45);
            Instantiate(chargeBullet, firepoint.position, firepoint.rotation);
        }
        else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            firepoint.rotation = Quaternion.Euler(0, 0, 135);
            Instantiate(chargeBullet, firepoint.position, firepoint.rotation);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            firepoint.rotation = Quaternion.Euler(0, 0, 90);
            Instantiate(chargeBullet, firepoint.position, firepoint.rotation);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || facingRight == false)
        {
            firepoint.rotation = Quaternion.Euler(0, 0, 180);
            Instantiate(chargeBullet, firepoint.position, firepoint.rotation);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || facingRight == true)
        {
            firepoint.rotation = Quaternion.Euler(0, 0, 0);
            Instantiate(chargeBullet, firepoint.position, firepoint.rotation);
        }
    }
}
