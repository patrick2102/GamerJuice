using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{

    [SerializeField]
    float speed = 3.5f;
    [SerializeField]
    Vector3 direction;

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
        this.transform.position += direction * speed * Time.deltaTime;
    }
}
