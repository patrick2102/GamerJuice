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

    private GameManager _instance;
    public GameObject canvas;

    public bool gameIsFinished = false;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(canvas);
        if (player == null) player = GameObject.Find("Player");
    }

    void Start()
    {
        _instance = GameManager.instance;
        _controller = player.GetComponent<PlayerForwardController>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(!gameIsFinished)
        {
            currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
            timerText.text = "Time: " + currentTime.ToString("0.00");

            //_controller = player.GetComponent<PlayerForwardController>();


            speed = _controller.currentSpeed;
            speedText.text = "Speed = " + speed.ToString("0.00");

            speedLevelText.text = "Speed Level = " + _instance.speedLevel.ToString();
        }
    }
}
