using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class LifeCycle : MonoBehaviour
{
    void Start()
    {
        //vector3 vec = new vector3(5, 0.1f, 5); // 벡터 값
        //transform.translate(vec);       // vector2 : 평면적인 것, vector3 : 입체적인 것
    }

    void Update()
    {
        Vector3 vec = new Vector3(0, 0.1f, 0);
        transform.Translate(vec);

    }

}
