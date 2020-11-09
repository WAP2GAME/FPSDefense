using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    float Speed;
    float time;
    public GameObject bullet;

    [SerializeField]
    private Gun currentGun;

    [SerializeField]
    private Camera theCam;

    private RaycastHit hitInfo;
    private Vector3 direction;

    public void OnEnable()
    {
        SetSpeed(1);
    }

    // Use this for initialization
    public void SetSpeed(float newSpeed)
    {
        Speed = newSpeed;
        time = Time.time + 2;
    }

   



    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction);

    }






    void OnTriggerEnter(Collider col)
    {



        if (col.gameObject.tag == "Target")
        {
            col.gameObject.SetActive(true);

        }
    }
}