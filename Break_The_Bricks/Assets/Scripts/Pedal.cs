using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedal : MonoBehaviour
{
    public AudioClip soundEffect;
    //private GameObject ball;        // silinecek

    void Start()
    {
        //ball = GameObject.Find("Ball");     // silinecek
    }


    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1f));       // farenin konumunu aldýk
        transform.position = new Vector3(Mathf.Clamp(mousePos.x, -3f, 3f), transform.position.y, transform.position.z);       // pedalýn konumunun x'ini farenin xine göre deðiþtirdik
        //transform.position = new Vector3(ball.transform.position.x,transform.position.y, transform.position.z);     // bu silinecek, üstteki çalýþacak
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        AudioSource.PlayClipAtPoint(soundEffect, transform.position);
    }
}
