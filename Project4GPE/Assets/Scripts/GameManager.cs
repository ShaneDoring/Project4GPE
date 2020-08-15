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
}
