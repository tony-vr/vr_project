using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
	[SerializeField] private float speed = 10f;
	public Vector3 _direction;

	void Update()
	{
		_direction.z = Input.GetAxis("Vertical");
		_direction.x = Input.GetAxis("Horizontal");
	}

	void FixedUpdate()
	{
		Move(Time.fixedDeltaTime);
	}

	private void Move(float delta)
	{
		transform.position += _direction.normalized * speed * delta;
	}

	
}
