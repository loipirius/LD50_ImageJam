using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public int numberToSpawn;
    public List<GameObject> spawnPool;
    public GameObject quad;
    public bool timeToSpawn;


    private void Start()
    {

    }

    private void Update()
    {
        if (timeToSpawn)
        {
            SpawnObject();
        }
    }

    public void SpawnObject()
    {
        int randomItem = 0;
        GameObject toSPawn;
        MeshCollider c = quad.GetComponent<MeshCollider>();


        float screenX, screenY;
        Vector2 pos;
        for (int i = 0; i < numberToSpawn; i++)
        {
            randomItem = Random.Range(0, spawnPool.Count);
            toSPawn = spawnPool[randomItem];

            screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
            screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
            
            pos = new Vector2(screenX,screenY);

            Instantiate(toSPawn, pos, toSPawn.transform.rotation);
            timeToSpawn = false;
        }
    }
    
    private void DestroyObjects()
    {
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("Spawnable"))
        {
            Destroy(o);
        }
    }
}
