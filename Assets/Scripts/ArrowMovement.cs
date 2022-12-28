using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{

    [SerializeField]
    float speed = 3.5f;
    [SerializeField]
    Vector3 direction;
    [SerializeField]
    float duration = 3.0f, lifeTime = 0.0f;
    

    public void setArrowMovement(Vector3 direction, float speed){
        this.speed = speed;
        this.direction = direction;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime += Time.deltaTime;
        if(lifeTime >= duration)
            Destroy(this.gameObject);
        this.transform.position += direction * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(!other.gameObject.tag.Equals("Enemy"))
            GameObject.Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(!other.gameObject.tag.Equals("Enemy"))
            GameObject.Destroy(this.gameObject);
    }
}
