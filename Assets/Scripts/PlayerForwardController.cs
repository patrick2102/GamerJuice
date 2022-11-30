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
    
    
    public Vector2 baseVelocity = new Vector2(1f, 0f);
    public Vector2 currentVelocity;
    public float speed;

    private void Awake()
    {
        game = GameManager.instance;
        rbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        speed = baseVelocity.x;
        currentVelocity = baseVelocity;
    }

    
    void Update()
    {
        currentVelocity = new Vector2(speed, rbody.velocity.y);
        rbody.velocity = currentVelocity;
    }

    private void FixedUpdate()
    {
        
    }

    public void ApplySpeedMultiplier()
    {
        speed = GameManager.speedMultiplier;
    }
}
