using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGoal : MonoBehaviour
{
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(GameManager.instance.worldPeaceMode)
            GameManager.instance.LoadScene(LevelsEnum.VictoryScreen);
        else
            GameManager.instance.LoadScene(LevelsEnum.VictoryScreenNormal);


        if (collision.gameObject.tag.Equals("Player"))
            Debug.Log("Player and won");
    }
}
