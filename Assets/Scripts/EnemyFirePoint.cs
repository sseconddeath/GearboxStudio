using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFirePoint : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;
    float fireRate;
    float nextFire;
    void Start()
    {
        fireRate = 1f;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        CheakIfTimeToFire();
    }
    void CheakIfTimeToFire()
    {
        if(Time.time > nextFire)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}
