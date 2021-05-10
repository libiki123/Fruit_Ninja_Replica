using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject[] fruitPrefabs;
    public Transform[] spawnPoints;

    public float minDelay = .1f;
    public float maxDelay = 1f;
    public float startForce = 15f;

    private void Start()
	{

        StartCoroutine(SpawnFuits());

	}

	IEnumerator SpawnFuits()
	{
        while (true)
		{
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));

            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            GameObject fruitGO = Instantiate(fruitPrefabs[Random.Range(0, fruitPrefabs.Length)], spawnPoint.position, spawnPoint.rotation);
            fruitGO.GetComponentInChildren<Rigidbody2D>().AddForce(spawnPoint.up * startForce, ForceMode2D.Impulse);        // add upward force when instansiate fruit

            Destroy(fruitGO, 5f);
        }
	}

}
