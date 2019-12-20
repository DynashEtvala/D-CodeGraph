using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public Vector3 Direction;
	public float Speed;
	[SerializeField] private float zDrift;
	[SerializeField] private bool returning;
	public float ReturnDistX;
	
	void Update()
	{
		if(((returning && (transform.position.x <= 0)) || ((transform.position.x >= ReturnDistX) && !returning)))
		{
			Direction = (Direction * -1f);
			zDrift = (zDrift * -1f);
			returning = !returning;
		}
		transform.Translate(0, 0, (zDrift * Time.deltaTime));
		transform.position = (transform.position + ((Direction * Speed) * Time.deltaTime));
	}
	
	void Start()
	{
		zDrift = 1.1f;
		returning = false;
	}
}
