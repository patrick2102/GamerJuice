using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForwardController : MonoBehaviour
{
    private GameManager game;
    private Rigidbody2D rbody;
    private BoxCollider2D collider;
    private SpriteRenderer sprite;

    public bool isBreak;
    public float breakTimer;
    private float breakDuration = 1f;
    
    public Vector2 baseVelocity = new Vector2(1f, 0f);
    public Vector2 currentVelocity;
    public Vector2 targetVelocity;
    public float speed;
    public float currentSpeed;
    public float topSpeed;

    public bool relativeForce;

    private void Awake()
    {
        game = GameManager.instance;
        rbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        isBreak = false;
        speed = baseVelocity.x;
        currentVelocity = baseVelocity;
        currentSpeed = 0f;
        topSpeed = 0f;
    }

    
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        currentSpeed = rbody.velocity.x;

        if (isBreak)
        {
            breakTimer -= Time.fixedDeltaTime;
            if (breakTimer <= 0f)
            {
                isBreak = false;
            }
            return;
        }

        if (currentSpeed < topSpeed)
        {

            Vector2 addVelocity = new Vector2(topSpeed, 0f);

            if (relativeForce)
            {
                rbody.AddRelativeForce(addVelocity);
            }
            else
            {
                rbody.AddForce(addVelocity);
            }
        }
        else
        {
            // player is at top speed for current speed level
            
        }

        //currentVelocity = new Vector2(speed, rbody.velocity.y);
        //rbody.velocity = currentVelocity;
    }

    
    private void GetAcceleration()
    {
        // TODO: Implement smoother velocity transition for rbody.AddForce()
    }

    public void Break(float power)
    {
        Debug.Log("Invoked Player Break!");
        isBreak = true;
        breakTimer = breakDuration;
        rbody.AddForce(new Vector2(-power, 0f), ForceMode2D.Impulse);
    }
    
    public void ApplySpeedMultiplier()
    {
        //speed = GameManager.speedMultiplier;
        topSpeed = GameManager.speedMultiplier;
    }
}
