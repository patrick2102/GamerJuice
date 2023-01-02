using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvlLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void loadLevel1()
    {
        LevelManager.instance.LoadScenelvlManager(LevelsEnum.JonasScene);
        if (UIManager.instance != null)
        {
            UIManager.instance.gameIsFinished = false;
            UIManager.instance.gameObject.SetActive(true);
            UIManager.instance.canvas.SetActive(true);
        }
    }

    public void loadLevel2()
    {
        LevelManager.instance.LoadScenelvlManager(LevelsEnum.TinoScene);
        if (UIManager.instance != null)
        {
            UIManager.instance.gameIsFinished = false;
            UIManager.instance.gameObject.SetActive(true);
            UIManager.instance.canvas.SetActive(true);
        }
    }
}
