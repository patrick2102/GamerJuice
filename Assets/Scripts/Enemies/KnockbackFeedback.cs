using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KnockbackFeedback : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] float delay = 0.15f;
    public UnityEvent OnBegin, OnDone;
    // Start is called before the first frame update
    void Start()
    {
        this.rb2d = GetComponent<Rigidbody2D>();
    }

    public void PlayFeedback(GameObject sender, float strength){
        StopAllCoroutines();
        OnBegin?.Invoke();
        Vector2 direction;
        if (WillPushUp(sender))
        {
            direction = Vector2.up;  
        }
        else
        {
            //direction = (transform.position - sender.transform.position).normalized;
            direction = Vector2.left;
            //direction = (sender.transform.position - transform.position).normalized;
        }
        rb2d.AddForce(direction * strength, ForceMode2D.Impulse);
        GameManager.instance.PenalizeSpeed(1);
        StartCoroutine(Reset());
    }

    private bool WillPushUp(GameObject sender)
    {
        // FIXME: Find top of collision object instead of naive transform origin
        if (transform.position.y > sender.transform.position.y) return true;
        return false;
    }
    
    private Vector2 FindPushDirection()
    {
        return Vector2.down;
    }

    private IEnumerator Reset(){
        yield return new WaitForSeconds(delay);
        rb2d.velocity = Vector3.zero;
        OnDone?.Invoke();
    }
}
