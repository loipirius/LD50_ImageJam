using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunnerLoader : MonoBehaviour
{
    private GameManager myGameManager;
    private GameObject gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        myGameManager = gameManager.GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            SceneManager.LoadScene("Runner", LoadSceneMode.Additive);
            myGameManager.myGameState = GameManager.GameState.MiniGame;
            Destroy(this.gameObject);
        }
    }
}
