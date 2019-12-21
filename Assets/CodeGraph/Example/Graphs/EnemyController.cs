using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	[SerializeField] private Vector3 startLocation;
	public Transform followTarget;
	public float speed;
	
	void Start()
	{
		startLocation = transform.position;
	}
	
	void Update()
	{
		transform.Translate(((followTarget.position - transform.position).normalized * (speed * Time.deltaTime)));
	}
	
	private void OnCollisionEnter(Collision collision)
	{
		transform.position = startLocation;
	}
}
