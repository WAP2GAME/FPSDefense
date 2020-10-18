using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Myball : MonoBehaviour
{
    Rigidbody rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    void FixedUpdate()
    {
        //rigid.velocity = new Vector3(2, 4, -1);   // #1. 속력 바꾸기

        
    }
}
