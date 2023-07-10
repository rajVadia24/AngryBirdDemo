using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public Enemies enemies;

	public Transform player;
	public float speed;

	private void OnEnable()
	{
		enemies.AddItem(this);
	}

	private void OnDisable()
	{
		enemies.RemoveItem(this);
	}

	private void Update()
	{
	 transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
	}

	private void OnTriggerEnter(Collider other)
	{
		gameObject.SetActive(false);
		enemies.RemoveItem(this);
	}
}
