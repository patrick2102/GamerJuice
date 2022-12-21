using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI speedText;


    [Header("Timer settings")]
    public float currentTime;
    public bool countDown;



    [Header("Speed settings")]
    public GameObject player;
    public float speed;
    private PlayerForwardController _controller;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        timerText.text = "Time: " + currentTime.ToString("0.00");

        _controller = player.GetComponent<PlayerForwardController>();


        speed = _controller.currentSpeed;
        speedText.text = "Speed = " + speed.ToString("0.00");

    }
}
