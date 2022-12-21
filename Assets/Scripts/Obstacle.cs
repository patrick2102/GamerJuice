using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public obstacleType obstacleType;
    private PlayerForwardController controller;
    float slowPercentage;

    // Start is called before the first frame update
    void Start()
    {
        switch(obstacleType)
        {
            case obstacleType.Wall:
            {
                slowPercentage = 50;
                break;
            }

            case obstacleType.Box:
            {

                slowPercentage = 35;
                break;
            }

            case obstacleType.Enemy:
            {
                slowPercentage = 35;
                break;
            }

            default:
            {
                slowPercentage = 1000;
                break;
            }
        }

        var player = GameObject.FindGameObjectsWithTag("Player").First();
        controller = player.GetComponent<PlayerForwardController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
       
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (obstacleType == obstacleType.Wall)
        {
            var rigidbody = collision.GetComponent<Rigidbody2D>();
            var force = Vector3.back * 3;
            Vector2 slow = new Vector2(0.01f * slowPercentage, 0.01f * slowPercentage);

            controller.currentVelocity *= slow;
            

        }
        if (obstacleType == obstacleType.Box)
        {

        }
        if (obstacleType == obstacleType.Enemy)
        {

        }

    }
}




public enum obstacleType
{
    Wall,
    Box,
    Enemy
}
