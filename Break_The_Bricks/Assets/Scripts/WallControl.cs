using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallControl : MonoBehaviour
{
    public AudioClip soundEffect;
    public GameObject collisionEffect;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        AudioSource.PlayClipAtPoint(soundEffect, transform.position);
        Vector3 pos = other.contacts[0].point;      // çarpýþmanýn oldupðu yerde
        GameObject go = Instantiate(collisionEffect, pos, Quaternion.identity) as GameObject;       // çarpýþma animasyonunu çalýþtýr
        Destroy(go, 1f);        // ve yok et
    }   
}
