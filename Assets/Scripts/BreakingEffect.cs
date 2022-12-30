using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingEffect : MonoBehaviour
{

    private BoxCollider2D collider;

    //public float breakPower;
    [SerializeField] private float strength;
    
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("BreakingEffect Collision Detected!");
        if (collision.gameObject.CompareTag("Player"))
        {
            //collision.gameObject.GetComponent<PlayerForwardController>().Break(breakPower);
            collision.gameObject.GetComponent<KnockbackFeedback>().PlayFeedback(this.gameObject, this.strength);
        } /*
        else if (collision.gameObject.CompareTag("Sword"))
        {
            //collision.gameObject.GetComponentInParent<PlayerForwardController>().Break(breakPower);
            collision.gameObject.GetComponentInParent<KnockbackFeedback>().PlayFeedback(this.gameObject, this.strength);
        }*/
    }
    
}
