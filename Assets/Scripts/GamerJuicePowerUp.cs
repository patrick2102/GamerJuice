using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamerJuicePowerUp : MonoBehaviour
{

    public BoxCollider2D collider;
    [SerializeField] private int speedLevelIncrease = 1;
    
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("Sword"))
        {
            GameManager.instance.IncreaseSpeed(speedLevelIncrease);
            Debug.Log("DRANK TEMPORAL GAMER JUICE");
            Destroy(this.gameObject);
        }
    }
}
