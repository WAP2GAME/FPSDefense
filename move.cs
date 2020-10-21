using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using unityEngine.InputSystem Classes;

public class move : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.Getkey(KeyCode.Space))
        {
           transform.Translate(vector3.up * speed * Timeout.deltaTime);
        }
    }
}
