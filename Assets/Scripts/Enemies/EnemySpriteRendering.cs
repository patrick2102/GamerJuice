using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpriteRendering : MonoBehaviour
{

    [SerializeField]
    SpriteRenderer sprite;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        sprite.flipX = player.transform.position.x > this.gameObject.transform.position.x;
    }
}
