using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

using System.Security.Cryptography;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    float Speed;
    float time;
    public int Damage = 20;


    public GameObject bullet;

    [SerializeField]
    private Gun currentGun;

    [SerializeField]
    private Camera theCam;

    private RaycastHit hitInfo;
    public Vector3 direction;


    private static GunController instance;
    public static GunController Instance { get { return instance; } }



    ObjectPool objectPool;




    void Start()
    {
     

        objectPool = ObjectPool.Instance;

        if (!objectPool.IsContainObject(bullet.name))
            objectPool.AddObject(bullet, bullet.name, 100);

    }


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
            Destroy(this.gameObject);
            Debug.Log("df");
        }
    }
}