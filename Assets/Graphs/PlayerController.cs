using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public Vector3 Direction;
	public float Speed;
	private float zDrift;
	
	void Update()
	{
		transform.Translate(0,0,zDrift * Speed);
		transform.position = transform.position + Direction * Speed * Time.deltaTime;
	}
	
	void Start()
	{
		zDrift = 1.1f;
	}
}
