//C:/Users/S189073/Documents/GitHub/CodeGraph/Assets/Graphs/PlayerController.cs
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed;
	[SerializeField] private int lives;
	public Vector3 startPosition;
	
	void Start()
	{
		lives = 3;
		startPosition = transform.position;
	}
	
	void Update()
	{
		transform.Translate(((Input.GetAxis("Horizontal") * speed) * Time.deltaTime), 0, ((Input.GetAxis("Vertical") * speed) * Time.deltaTime));
	}
	
	private void OnCollisionEnter(Collision collision)
	{
		lives = (lives - 1);
		if((lives <= 0))
		{
			Destroy(gameObject);
		}
		transform.position = startPosition;
	}
}
