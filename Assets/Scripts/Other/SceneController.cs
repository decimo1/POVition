﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class SceneController : MonoBehaviour
{
    public string menuScene;
    public TeleportationController teleportationController;

    private void Awake()
    {
        foreach(GameObject obj in SceneManager.GetActiveScene().GetRootGameObjects())
        {
            DontDestroyOnLoad(obj);
        }
        LoadMenuScene();
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    public void LoadScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }

    public void LoadMenuScene()
    {
        LoadScene(menuScene);
    }

    public virtual void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            LoadScene(nextSceneIndex);
        }
        else
        {
            LoadMenuScene();
        }
    }


    private void OnLevelWasLoaded(int level)
    {
        teleportationController.InitializeTeleportation();
    }
}
