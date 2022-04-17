using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Game,
        GameLoss,
        MiniGame
    }

    public GameState myGameState;
    public Image timerFill;
    private float timer;
    [SerializeField] private float startTime;

    [SerializeField] private float timeScore;
    private static GameManager instance;
    public int finalScore;
    [SerializeField] private GameObject myPlayer;
    private SpriteRenderer playerRenderer;
    public int minigameCount;
    public bool gameEnded = false;
    public GameObject piso;
    public GameObject walls;
    public GameObject mySpawner;
    public GameObject myCanvas;
    public GameObject myEventSystem;
    public GameObject myWalls;
    
    
    
    void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
 
        instance = this;
    }
    
    void Start()
    {
        playerRenderer= myPlayer.GetComponent<SpriteRenderer>();
        timer = startTime;
        myGameState = GameState.Game;
    }

    void Update()
    {
        switch (myGameState)
        {
            case GameState.Game:
                myWalls.SetActive(true);
                if (myPlayer.activeSelf == false)
                {
                    myPlayer.SetActive(true);
                }

                if (myPlayer.activeSelf == true)
                {
                    timer -= Time.deltaTime;

                }
                timerFill.fillAmount = timer / 100;
                Scorer();
                if (timer < 0)
                {
                    myGameState = GameState.GameLoss;
                    gameEnded = true;
                    Debug.Log("CHANGED STATE TO LOSS");
                }
                
                Debug.Log(timer);
                break;
            
            case GameState.MiniGame:
                Scorer();
                myWalls.SetActive(false);
                Debug.Log("you are playing a minigame!"); 
                break;

            case GameState.GameLoss:
                
                Debug.Log(finalScore);
                if (gameEnded)
                {
                    myPlayer.GetComponent<SpriteRenderer>().enabled = false;
                    GameObject[] portals = GameObject.FindGameObjectsWithTag("Portal");
                    piso.SetActive(false);
                    walls.SetActive(false);
                    mySpawner.SetActive(false);
                    myCanvas.SetActive(false);
                    myEventSystem.SetActive(false);
                    if (portals.Length > 0)
                    {
                        foreach (var GameObject in portals)
                        {
                            Destroy(GameObject);
                        }
                    }
                    SceneManager.LoadScene("EndGame", LoadSceneMode.Additive);
                    myPlayer.GetComponentInChildren<Camera>().enabled = false;
                    gameEnded = false;
                }

                //display game over screen + results;
                break;
        }
    }


    private int Scorer()
    {
        timeScore += Time.deltaTime;
        finalScore = (int) timeScore;
        return finalScore;
    }
   
}
