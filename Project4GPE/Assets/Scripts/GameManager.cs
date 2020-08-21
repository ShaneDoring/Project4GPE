using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int currentSceneIndex=0;
    public int points;
    public int playerLives = 3;
    public string gameState = "Title Screen";

    public GameObject playerPrefab;
    public GameObject player;
    public GameObject playerSpawnPoint;
    

    public void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Debug.LogError("Game manager tried to load in a second game manager");
            Destroy(this);
        }

    }

    private void Start()
    {
        //SpawnPlayer();
    }

    private void Update()
    {
      //  if (Input.GetKeyDown(KeyCode.A))
      //  {
     //       LoadNextScene();
      //  }
      
        //FSM GAME STATE

        //Title Screen
        if(gameState=="Title Screen")
        {
            //do nothing

            //wait for user input
            if (Input.anyKey)
            {
                StartGame();
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }

        //In Game
        if(gameState=="In Game")
        {
            //do behaviour
            if (GameManager.instance.player == null)
            {
                SpawnPlayer();
            }
            //check for transitions
            if (GameManager.instance.playerLives <= 0)
            {
                LoadLevel(4);             
                ChangeState ("Game Over");
            }

        }

        //Player Death
        if(gameState=="Player Death")
        {
            //do behaviour

            //check for transitions
        }

        //Victory Screen
        if (gameState=="Victory Screen")
        {
            //do behaviour

            //check for transitions

        }

        if (gameState=="Game Over")
        {
            //wait for player

            //transitions
            if (Input.anyKey)
            {
                Retry();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }

        }

 

        





    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.LogError("Scene finished loading..");
        currentSceneIndex = scene.buildIndex;
    }

    public void LoadNextScene()
    {
        LoadLevel(currentSceneIndex + 1);
    }

    public void ChangeState(string newState)
    {
        gameState = newState;
    }

    public void SpawnPlayer()
    {   
        //if(GameManager.instance.playerLives>0)
        {
            player = Instantiate(playerPrefab, playerSpawnPoint.transform.position, Quaternion.identity);
        }

        
    }

    

    public void StartGame()
    {
        
        LoadLevel(1);
        ChangeState("In Game");
        
    }


    public void Retry()
    {
        playerLives += 3; 
        LoadLevel(0);
        ChangeState("Title Screen");
      
        
    }

  


}
