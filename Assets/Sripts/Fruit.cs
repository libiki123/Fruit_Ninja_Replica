using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
	public GameObject fruit;
	public GameObject slidedFruit;

	private void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.tag == "Blade")
		{
			Vector3 direction = transform.position - coll.transform.position;

			Quaternion rotation = coll.transform.position.y > transform.position.y ?	// rotate base on upward or downward slide
				Quaternion.LookRotation(direction) * Quaternion.FromToRotation(Vector3.forward, Vector3.up)
				: Quaternion.LookRotation(direction) * Quaternion.FromToRotation(Vector3.up, Vector3.forward);

			fruit.SetActive(false);
			slidedFruit.SetActive(true);

			slidedFruit.transform.position = transform.position;
			slidedFruit.transform.rotation = rotation;
		}
	}
}
