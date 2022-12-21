using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    float velocity = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(velocity, 0, 0) * Time.deltaTime;
    }

    public void decreaseSpeed(float multiplier){
        velocity *= (1 - multiplier);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag.Equals("Enemy")){
            if(!other.GetComponent<EnemyCollision>().isParried())
                decreaseSpeed(0.5f);
        }

        if(other.tag.Equals("Projectile"))
            decreaseSpeed(0.1f);
    }
}
