using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimation : MonoBehaviour
{
    private Vector3 firstPos;

    void Start()
    {
        firstPos = transform.position;
        transform.position = new Vector3(firstPos.x, firstPos.y-6, firstPos.z);     // kamerayý 6 birim aþaðý aldýk
    }


    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, firstPos, 2 * Time.deltaTime);    
    }
}
