using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject boxPrefabs;
    public float spawnInterval;
    public Vector2 arenaSizeFromCenter;
    public float noSpawnDistance = 2f;
    [Space]
    public Transform player;

    private float nextSpawn;

    private void Start()
    {
        nextSpawn = spawnInterval;
    }

    private void Update()
    {
        nextSpawn -= Time.deltaTime;
        if (nextSpawn <= 0)
        {
            Vector3 rndPos = GetRandomPos();
            while (Vector3.Distance(player.position, rndPos) < noSpawnDistance)
            {
                rndPos = GetRandomPos();
            }

            Instantiate(boxPrefabs, rndPos, Quaternion.identity, transform);
            nextSpawn = spawnInterval;
        }
    }

    private Vector3 GetRandomPos()
    {
        var box = Instantiate(boxPrefabs, transform);

        float x = Random.Range(-arenaSizeFromCenter.x, arenaSizeFromCenter.x);
        float y = Random.Range(-arenaSizeFromCenter.y, arenaSizeFromCenter.y);
        return new Vector3(x, y);
    }
}
