using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public Vector3 Direction;

    void Update()
    {
        transform.position = transform.position + Direction * Speed * Time.deltaTime;
    }
}

