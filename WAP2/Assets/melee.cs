using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class melee : MonoBehaviour
{
    private IEnumerator SayHi()
    {
        while (true)
        {
            Debug.Log("hi");
            yield return new WaitForSeconds(0.5f);
        }
    }
    void Start()
    {
        StartCoroutine(SayHi());
    }
}

