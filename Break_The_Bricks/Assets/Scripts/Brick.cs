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
        maxCollisionNum = brickSprites.Length + 1;      // toplam çarpýþma sayýsý sprite büyüklüðünün 1 fazlasý olsun
        totalBrickNum++;        // oyun baþladýðýnda her üretilen tuðla için static toplam tuðla sayýsý deðiþkenini 1 artýr
        scoreScript = GameObject.FindObjectOfType<Score>().GetComponent<Score>();
    }


    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Equals("Ball"))       // topla çarpýþýrsa
        {
            scoreScript.IncreaseScore();
            collisionNum++;             // çarpýþma sayýsýný 1 arttýr    
            if(collisionNum >= maxCollisionNum)     // çarpýþma sayýsý max çarpýþma sayýsýndan büyük veya eþitse
            {
                AudioSource.PlayClipAtPoint(soundEffectBrickBroke, transform.position);
                Vector3 pos = other.contacts[0].point;      // çarpýþmanýn oldupðu yerde
                GameObject go = Instantiate(breakingEffect, pos, Quaternion.identity) as GameObject;       // çarpýþma animasyonunu çalýþtýr
                Destroy(go, 1f);        // ve yok et
                Destroy(this.gameObject);       // objeyi yok et
                totalBrickNum--;        // toplam tuðla sayýsýný 1 eksilt
                if (totalBrickNum <= 0)     // toplam tuðla sayýsý 0 veya 0'dan küçükse
                {
                    GameObject.FindObjectOfType<GameControl>().GetComponent<GameControl>().NextScene();
                    // GameControl scripti var olan oyun objesini bulup, onun üzerindeli GameControl Scriptinin NexScene metodunu çalýþtýrýyoruz
                }
            }
            else        // çarpýþma sayýsý maxÇarpýþmaSayýsýndan küçükse
            {
                AudioSource.PlayClipAtPoint(soundEffectBrickCollision, transform.position);
                GetComponent<SpriteRenderer>().sprite = brickSprites[collisionNum - 1];     // spriteyi deðiþtir (belirli bir sýraya göre)
            }
        }
    }
}
