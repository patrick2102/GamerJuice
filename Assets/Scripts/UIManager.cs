using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI speedLevelText;


    [Header("Timer settings")]
    public float currentTime;
    public bool countDown;



    [Header("Speed settings")]
    public GameObject player;
    public float speed;
    private PlayerForwardController _controller;


    public static UIManager instance;
    public GameObject canvas;

    public bool gameIsFinished = false;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            Destroy(canvas);
            return;
        }
        instance = this;
        DontDestroyOnLoad(instance);
        DontDestroyOnLoad(canvas);


        if (player == null) player = GameObject.Find("Player");
        _controller = player.GetComponent<PlayerForwardController>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   
        if(!gameIsFinished)
        {
            //currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
            currentTime = GameManager.instance.elapsedTime;
            timerText.text = "Time: " + currentTime.ToString("0.00");

            //_controller = player.GetComponent<PlayerForwardController>();


            speed = _controller.currentSpeed;
            speedText.text = "Speed = " + speed.ToString("0.00");

            speedLevelText.text = "Speed Level = " + GameManager.instance.speedLevel.ToString();
        }
    }
}
