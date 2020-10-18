using UnityEngine;
using System.Collections;

public class addforce : MonoBehaviour
{
    void OnMouseDown()
    {
        GetComponent<Rigidbody>().AddForce(-transform.forward * 500);
        GetComponent<Rigidbody>().useGravity = true;
    }
}