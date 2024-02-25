using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    static bool isMusicExist;

    void Start()
    {
        if (!isMusicExist)
        {
            GameObject.DontDestroyOnLoad(this.gameObject);
            isMusicExist = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Update()
    {
        
    }
}
