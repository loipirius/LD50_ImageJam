using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunnerManager : MonoBehaviour
{
    [SerializeField] private GameObject myPlayer;
    private GameManager myGameManager;
    private GameObject gameManager;
    private GameObject objectSpawner;
    private Spawner mySpawner;
    
    private void Start()
    {
        objectSpawner = GameObject.FindGameObjectWithTag("Spawner");
        mySpawner = objectSpawner.GetComponent<Spawner>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        myGameManager = gameManager.GetComponent<GameManager>();
    }
    private void Update()
    {
        if (myPlayer == null || myGameManager.myGameState != GameManager.GameState.MiniGame)
        {
            mySpawner.timeToSpawn = true;
            myGameManager.myGameState = GameManager.GameState.Game;
            myGameManager.minigameCount++;
            SceneManager.UnloadSceneAsync("Runner", UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
        }
    }
}
