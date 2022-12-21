using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{

    bool parried = false;
    [SerializeField] private float strength;
    // Start is called before the first frame update
    void Start(){

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isParried(){
        return parried;
    }

    public void setParried(bool parried){
        this.parried = parried;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag.Equals("Player")){
            Debug.Log("Here");
            other.gameObject.GetComponent<KnockbackFeedback>().PlayFeedback(this.gameObject, this.strength);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag.Equals("Player")){
            Debug.Log("There");
            other.gameObject.GetComponent<KnockbackFeedback>().PlayFeedback(this.gameObject, this.strength);
        }
    }
}
