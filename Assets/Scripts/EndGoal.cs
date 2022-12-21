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
        if (collision.gameObject.tag.Equals("Player")) {
            if (GameManager.instance.worldPeaceMode)
                GameManager.instance.LoadScene(LevelsEnum.VictoryScreen);
            else
                GameManager.instance.LoadScene(LevelsEnum.VictoryScreenNormal);
            UIManager.gameIsFinished = true;
        }
    }
}
