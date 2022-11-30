using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager instance;
    public float elapsedTime;
    
    private void Awake()
    {
        instance = this;
        elapsedTime = 0f;
    }

    
    void Start()
    {
        
    }

    
    void Update()
    {
        elapsedTime += Time.deltaTime;
        
    }

    void Restart()
    {
        
    }
}
