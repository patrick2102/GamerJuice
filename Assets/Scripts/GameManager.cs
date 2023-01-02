using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public LevelsEnum currentLevel;
    public static GameManager instance;
    public AudioSource bg;
    public GameObject player;

    [Header("Speed Settings")]
    public float speedIncreaseInterval = 5f;
    public float speedIncreaseAmount = 0.2f;
    public float initSpeedMultiplier = 1f;
    public int MaxSpeedLevel = 50;
    public int MinSpeedLevel; // Use in case of certain required speeds etc
    private float intervalTimer;

    public static float speedMultiplier;
    [Header("Current Runtime Values")]
    public float elapsedTime;
    public int speedLevel;

    [Header("World Peace?")]
    public bool worldPeaceMode = false;

    private void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);
        instance = this;
        elapsedTime = 0f;
        speedLevel = 1;
        intervalTimer = 0f;
        if (player == null) player = GameObject.Find("Player");
    }


    void Start()
    {
        speedMultiplier = initSpeedMultiplier;
        worldPeaceMode = false;

        //LoadScene(currentLevel);

        Debug.Log("Number of levels available: " + SceneManager.sceneCountInBuildSettings);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) Restart();

        // TODO: In case of speedLevel penalties, change from accumulated time to time interval

        elapsedTime += Time.deltaTime;
        intervalTimer += Time.deltaTime;

        if (intervalTimer > speedIncreaseInterval)
        {
            IncreaseSpeed(1);
            intervalTimer = 0f;
        }

        /*
        if (elapsedTime > speedLevel * speedIncreaseInterval)
        {
            speedLevel++;
            speedMultiplier += speedIncreaseAmount;
            player.GetComponent<PlayerForwardController>().ApplySpeedMultiplier();
        }*/

        if (Input.GetKey(KeyCode.P))
        {
            worldPeaceMode = true;
            Debug.Log("World peace mode!");
        }
    }

    public void IncreaseSpeed(int increase)
    {
        for (int i = increase; i > 0; i--)
        {
            if (speedLevel + 1 > MaxSpeedLevel) break;
            speedLevel++;
            speedMultiplier += speedIncreaseAmount;
        }
        player.GetComponent<PlayerForwardController>().ApplySpeedMultiplier();
    }

    public void PenalizeSpeed(int penalty)
    {
        for (int i = penalty; i > 0; i--)
        {
            if (speedLevel - 1 < MinSpeedLevel) break;
            speedLevel--;
            speedMultiplier -= speedIncreaseAmount;
            Debug.Log($"Speed level decreased to {speedLevel}");
        }
        player.GetComponent<PlayerForwardController>().ApplySpeedMultiplier();
    }

    public void Restart()
    {
        var targetScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(targetScene.name);
    }


    public void LoadScene(LevelsEnum levelToLoad)
    {
        SceneManager.LoadScene(levelToLoad.ToString());
    }
}
