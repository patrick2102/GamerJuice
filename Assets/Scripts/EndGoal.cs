using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGoal : MonoBehaviour
{
    public UIManager UIManager;
    public int scene;

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag.Equals("Player")) {
            if(scene == 1)
            {
                if (UIManager.instance.currentTime < LevelManager.instance.times[1])
                {
                    LevelManager.instance.times[1] = UIManager.instance.currentTime;
                }
            }
            if (scene == 2)
            {
                if(UIManager.instance.currentTime < LevelManager.instance.times[2])
                {
                    LevelManager.instance.times[2] = UIManager.instance.currentTime;
                }
            }

            LevelManager.instance.times[0] = UIManager.instance.currentTime;

            UIManager.instance.gameIsFinished = true;
            UIManager.instance.gameObject.SetActive(false);
            UIManager.instance.canvas.SetActive(false);
            if (GameManager.instance.worldPeaceMode)
                GameManager.instance.LoadScene(LevelsEnum.VictoryScreen);
            else
                GameManager.instance.LoadScene(LevelsEnum.VictoryScreenNormal);
            //UIManager.gameIsFinished = true;
        }
    }



}
