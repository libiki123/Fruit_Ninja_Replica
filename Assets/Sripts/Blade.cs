using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
	private bool isCutting;
	private Rigidbody2D rb;
	private Collider2D coll;
	private Camera cam;
	[SerializeField] private GameObject trail;
	private Vector2 previousPos;

	public float minCuttingVelocity = 0.001f;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		coll = GetComponent<Collider2D>();
		cam = Camera.main;
	}

	void Update()
    {
		if (Input.GetMouseButtonDown(0))
		{
			Cutting();
		}
		else if (Input.GetMouseButtonUp(0))
		{
			StopCutting();
		}

		if (isCutting)
		{
			UpdateCut();
		}
    }

	private void UpdateCut()
	{
		Vector2 mousePos = GetMousePos();
		rb.position = mousePos;

		float velocity = (mousePos - previousPos).magnitude * Time.deltaTime;			// check velocity, compare to minimun swipe speed to cut
		if (velocity > minCuttingVelocity)
		{
			coll.enabled = true;
		}
		else
		{
			coll.enabled = false;
		}

		previousPos = mousePos;
	}

	private Vector2 GetMousePos()
	{
		Vector3 mouse = Input.mousePosition;
		mouse.z = 10;
		return cam.ScreenToWorldPoint(mouse);
	}

	private void StopCutting()
	{
		isCutting = false;
		trail.SetActive(false);
		coll.enabled = false;
	}

	private void Cutting()
	{
		isCutting = true;
		trail.SetActive(true);
		previousPos = GetMousePos();			// when left click in new pos make sure previous pos doesnt start from previous left click
	}
}
