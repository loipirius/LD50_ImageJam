using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunnerLoader : MonoBehaviour
{
    public enum MiniGames
    {
        Runner,
        Jumper,
        Shooter
    }

    public MiniGames miniGameToLoad;
    public GameManager myGameManager;
    public GameObject gameManager;
    private SpriteRenderer myRenderer;
    public bool usable = false;
    public float useTimer;
    
    private void Start()
    {
        myRenderer = gameObject.GetComponent<SpriteRenderer>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        myGameManager = gameManager.GetComponent<GameManager>();
        myRenderer.enabled = false;
    }

    private void Update()
    {
        if (usable == false)
        {
            useTimer += Time.deltaTime;
            if (useTimer >= 0.5f)
            {
                myRenderer.enabled = true;
                usable = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        /*if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            SceneManager.LoadScene("Scenes/Runner", LoadSceneMode.Additive);
            myGameManager.myGameState = GameManager.GameState.MiniGame;
            Destroy(this.gameObject);
        }*/

        switch (miniGameToLoad)
        {
            case MiniGames.Runner:
                if (other.gameObject.CompareTag("Player") && usable)
                {
                    other.gameObject.SetActive(false);
                    SceneManager.LoadScene("Scenes/Runner", LoadSceneMode.Additive);
                    myGameManager.myGameState = GameManager.GameState.MiniGame;
                    Destroy(this.gameObject);
                }
                else
                {
                    enableSpawn();
                    Destroy(gameObject);
                }
                break;
                
                
            case MiniGames.Jumper:
                if (other.gameObject.CompareTag("Player") && usable)
                {
                    other.gameObject.SetActive(false);
                    SceneManager.LoadScene("Scenes/Jumper", LoadSceneMode.Additive);
                    myGameManager.myGameState = GameManager.GameState.MiniGame;
                    Destroy(this.gameObject);
                }
                else
                {
                    enableSpawn();
                    Destroy(gameObject);
                }
                break;
                
                
            case MiniGames.Shooter:
                if (other.gameObject.CompareTag("Player") && usable)
                {
                    other.gameObject.SetActive(false);
                    SceneManager.LoadScene("Shooter", LoadSceneMode.Additive);
                    myGameManager.myGameState = GameManager.GameState.MiniGame;
                    Destroy(this.gameObject);
                }
                else
                {
                    enableSpawn();
                    Destroy(gameObject);
                }
                break;
        }
    }

    private void enableSpawn()
    {
        var Spawner = GameObject.FindGameObjectWithTag("Spawner");
        Spawner.GetComponent<Spawner>().timeToSpawn = true;
    }
}
