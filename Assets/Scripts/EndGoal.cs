using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGoal : MonoBehaviour
{
    public UIManager UIManager;

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.instance.LoadScene(LevelsEnum.VictoryScreen);

        if (collision.gameObject.tag.Equals("Player"))
            Debug.Log("Player entered");

        UIManager.gameIsFinished = true;
    }
}
