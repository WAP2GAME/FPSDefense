using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transform : MonoBehaviour
{

    void Update()
    {
        transform.Translate((Vector3.right) * Time.deltaTime, Space.World);

    }
}
