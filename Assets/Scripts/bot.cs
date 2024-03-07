using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class bot : MonoBehaviour
{
    public float startWaitTime;
    public float waitTime;
public float speed = 3f;
private Vector2 moveVector;
public SpriteRenderer sr;
public Transform[] moveSpots;
private int randomspot;
    // Start is called before the first frame update
    void Start()
    {

        randomspot = Random.Range(0,moveSpots.Length);
        waitTime = startWaitTime;
    }
   void Update()
   {
    transform.position = Vector3.MoveTowards(transform.position,moveSpots[randomspot].position,speed*Time.deltaTime);
     if (Vector2.Distance(transform.position,moveSpots[randomspot].position)< 0.2f)
     {
        if (waitTime<= 0)
        {
            randomspot = Random.Range (0, moveSpots.Length);
            waitTime = startWaitTime;
        }
        else
        {waitTime -=Time.deltaTime;
        }
     }
     Flip();
   }
    void Flip() //������� ���������
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
}
