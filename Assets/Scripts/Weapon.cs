using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bullet;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        Instantiate(bullet, firepoint.position, firepoint.rotation);
    }
}
