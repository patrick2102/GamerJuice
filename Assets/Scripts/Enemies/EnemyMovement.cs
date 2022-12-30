using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 1.5f;

    [SerializeField]
    bool isMoving;

    [SerializeField]
    float ChaseDistance;
    [SerializeField]
    SpriteRenderer sprite;

    float direction = 1;

    private void Awake()
    {
        if (sprite == null) sprite = GetComponent<SpriteRenderer>();
    }


    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Vector3.Distance(GameObject.FindWithTag("Player").transform.position, transform.position);
        isMoving = (distToPlayer <= ChaseDistance);
        if(isMoving)
            transform.position -= new Vector3(speed,0) * Time.deltaTime * direction;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("collided");
        if(!other.gameObject.tag.Equals("Player") && !other.gameObject.tag.Equals("Projectile")){
            direction *= -1;
            sprite.flipX = !sprite.flipX;
        }
    }

    private void OnDrawGizmos() {
        
        Gizmos.color = Color.green;
        //Gizmos.DrawLine(transform.position, transform.position + (target.transform.position - this.transform.position).normalized * range);
        Gizmos.DrawWireSphere(transform.position, ChaseDistance);
    }
}
