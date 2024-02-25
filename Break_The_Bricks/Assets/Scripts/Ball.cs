using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private GameObject pedal;
    private bool isGameBegin = false;

    void Start()
    {
        pedal = GameObject.FindObjectOfType<Pedal>().gameObject;       // üzerinde Pedal scripti var olan objeyi buluyor
    }


    void Update()
    {
        if (!isGameBegin)
        {
            transform.position = new Vector3 (pedal.transform.position.x, transform.position.y, transform.position.z);
            if (Input.GetMouseButtonDown(0))
            {
                float velocityX;
                if (Random.Range(-1f, 1f)<0)
                {
                    velocityX = -2f;
                }
                else
                {
                    velocityX = 2f;
                }

                GetComponent<Rigidbody2D>().velocity = new Vector2(velocityX, 9f);
                isGameBegin = true;
            }
            
        }
       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(isGameBegin)
        {
            if (other.gameObject.name.Equals(pedal.gameObject.name))        // top pedala çarparsa
            {
                GetComponent<Rigidbody2D>().velocity += new Vector2(Random.Range(-0.1f, 0.1f), 0.05f);      // x hýzýna rastgele bir hýz eklensin, y'ye de minik bir hýz eklensin
            }
        }
        
    }
}
