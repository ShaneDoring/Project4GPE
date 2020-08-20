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
        SpawnPlayer();
    }

    private void Update()
    {
      /*  if (Input.GetKeyDown(KeyCode.A))
        {
            LoadNextScene();
        }*/
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

    public void SpawnPlayer()
    {
        if (GameManager.instance.player == null && GameManager.instance.playerLives > 0)
        {
            player = Instantiate(playerPrefab, playerSpawnPoint.transform.position, Quaternion.identity);
        }

        
    }
}
