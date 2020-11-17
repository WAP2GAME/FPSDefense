using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

using System.Security.Cryptography;
using UnityEngine;

public class Bullet : MonoBehaviour
{


    // 레이저 충돌 정보 받아옴.
    private RaycastHit hitInfo;



    float speed = 0.1f;
    float time;
    public int Damage = 20;


    public Vector3 direction;

    public void OnEnable()
    {
        //타임 변수 초기화
        time = Time.time;
    }


    // Update is called once per frame
    void Update()
    {
        //transform.forward = 이 오브젝트의 정면 벡터 값
        //translate == 현재 오브젝트의 포지션에서 인자로 주어진 벡터 값을 더함
        transform.Translate(transform.forward * speed);

        if (Time.time > time + 2 && gameObject.activeSelf)
            gameObject.SetActive(false);

 
    }

    
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Target")
        {
            col.gameObject.SetActive(true);
            Debug.Log("df");
            if (gameObject.activeSelf)
                gameObject.SetActive(false);
        }

  
    }
}
