﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    float Speed;
    float time;

    // Use this for initialization
    public void SetSpeed(float newSpeed)
    {
        Speed = newSpeed;
        time = Time.time + 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);

        if (Time.time > time)
            Destroy(this.gameObject);
    }
}