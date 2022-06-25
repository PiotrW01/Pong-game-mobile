using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

	Rigidbody2D rb;
	float dirX;
	float moveSpeed = 8f;
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		Debug.Log(this.transform.localScale);
		if (PlayerPrefs.GetInt("size") == 1)
		{
			this.transform.localScale = new Vector3(2.0f, 0.3f, 1f);
		}
		else if (PlayerPrefs.GetInt("size") == -1)
		{
			this.transform.localScale = new Vector3(1.0f, 0.3f, 1.0f);
		}
	}

	void Update()
	{
		if (Input.acceleration.x > 0.2f || Input.acceleration.x < -0.2f)
		{

			dirX = Input.acceleration.x * moveSpeed;
		}
		if (Input.GetKey(KeyCode.A))
		{
			dirX = -1.0f * moveSpeed;
		}
		if (Input.GetKey(KeyCode.D))
		{
			dirX = 1.0f * moveSpeed;
		}

	}

	void FixedUpdate()
	{
		rb.velocity = new Vector2(dirX, 0f);
		dirX = 0;
	}



}
