using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public AudioClip soundEffectBrickBroke;
    public AudioClip soundEffectBrickCollision;

    public GameObject breakingEffect;


    public Sprite[] brickSprites;
    private int maxCollisionNum;
    private int collisionNum;

    public static int totalBrickNum;

    private Score scoreScript;

    void Start()
    {
        maxCollisionNum = brickSprites.Length + 1;      // toplam �arp��ma say�s� sprite b�y�kl���n�n 1 fazlas� olsun
        totalBrickNum++;        // oyun ba�lad���nda her �retilen tu�la i�in static toplam tu�la say�s� de�i�kenini 1 art�r
        scoreScript = GameObject.FindObjectOfType<Score>().GetComponent<Score>();
    }


    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Equals("Ball"))       // topla �arp���rsa
        {
            scoreScript.IncreaseScore();
            collisionNum++;             // �arp��ma say�s�n� 1 artt�r    
            if(collisionNum >= maxCollisionNum)     // �arp��ma say�s� max �arp��ma say�s�ndan b�y�k veya e�itse
            {
                AudioSource.PlayClipAtPoint(soundEffectBrickBroke, transform.position);
                Vector3 pos = other.contacts[0].point;      // �arp��man�n oldup�u yerde
                GameObject go = Instantiate(breakingEffect, pos, Quaternion.identity) as GameObject;       // �arp��ma animasyonunu �al��t�r
                Destroy(go, 1f);        // ve yok et
                Destroy(this.gameObject);       // objeyi yok et
                totalBrickNum--;        // toplam tu�la say�s�n� 1 eksilt
                if (totalBrickNum <= 0)     // toplam tu�la say�s� 0 veya 0'dan k���kse
                {
                    GameObject.FindObjectOfType<GameControl>().GetComponent<GameControl>().NextScene();
                    // GameControl scripti var olan oyun objesini bulup, onun �zerindeli GameControl Scriptinin NexScene metodunu �al��t�r�yoruz
                }
            }
            else        // �arp��ma say�s� max�arp��maSay�s�ndan k���kse
            {
                AudioSource.PlayClipAtPoint(soundEffectBrickCollision, transform.position);
                GetComponent<SpriteRenderer>().sprite = brickSprites[collisionNum - 1];     // spriteyi de�i�tir (belirli bir s�raya g�re)
            }
        }
    }
}
