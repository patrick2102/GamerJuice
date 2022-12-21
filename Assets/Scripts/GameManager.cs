using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public LevelsEnum currentLevel;
    public static GameManager instance;
    public static float speedMultiplier;
    
    public GameObject player;
    public float elapsedTime;
    public float initSpeedMultiplier = 1f;
    public int speedLevel;
    public float speedIncreaseInterval = 5f;
    public float speedIncreaseAmount = 0.2f;
    
    private void Awake()
    {
        instance = this;
        elapsedTime = 0f;
        speedLevel = 1;
    }

    
    void Start()
    {
        speedMultiplier = initSpeedMultiplier;

        //LoadScene(currentLevel);

        Debug.Log("Number of levels available: " + SceneManager.sceneCountInBuildSettings);
    }

    
    void Update()
    {
        // TODO: In case of speedLevel penalties, change from accumulated time to time interval
        
        elapsedTime += Time.deltaTime;

        if (elapsedTime > speedLevel * speedIncreaseInterval)
        {
            speedLevel++;
            speedMultiplier += speedIncreaseAmount;
            player.GetComponent<PlayerForwardController>().ApplySpeedMultiplier();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(currentLevel.ToString());
    }


    public void LoadScene(LevelsEnum levelToLoad)
    {
        SceneManager.LoadScene(levelToLoad.ToString());
    }
}
