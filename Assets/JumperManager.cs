using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class JumperManager : MonoBehaviour
{
    public GameObject[] platformPrefabs;
    public GameObject myPlayer;
    
    private GameManager myGameManager;
    private GameObject gameManager;
    private GameObject objectSpawner;
    private Spawner mySpawner;
    
    public int platformCount = 300;

    private void Start()
    {
        objectSpawner = GameObject.FindGameObjectWithTag("Spawner");
        mySpawner = objectSpawner.GetComponent<Spawner>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        myGameManager = gameManager.GetComponent<GameManager>();
        
        Vector3 spawnPosition = new  Vector3();

        for (int i = 0; i < platformCount; i++)
        {
            spawnPosition.y += Random.Range(.5f, 2f);
            spawnPosition.x = Random.Range(-5f, 5f);
            var newPlatform = Instantiate(platformPrefabs[Random.Range(0,platformPrefabs.Length)], spawnPosition, quaternion.identity);
            newPlatform.transform.parent = this.gameObject.transform;
        }
    }
    
    private void Update()
    {
        if (myPlayer == null || myGameManager.myGameState != GameManager.GameState.MiniGame)
        {
            mySpawner.timeToSpawn = true;
            myGameManager.myGameState = GameManager.GameState.Game;
            myGameManager.minigameCount++;
            SceneManager.UnloadSceneAsync("Jumper", UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
        }
    }
}
