using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public List<float> times;
    //public TextMeshProUGUI lvl1Text;
    //public TextMeshProUGUI lvl2Text;
    public static LevelManager instance;


    private void Awake()
    {
        
        if (instance != null)
        {
            Destroy(this);
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this); 
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        times.Add(0.00f);
        times.Add(Mathf.Infinity);
        times.Add(Mathf.Infinity);
        if (UIManager.instance != null)
        {
            UIManager.instance.gameIsFinished = true;   
        }
        
    }

    public void Update()
    {
        //lvl1Text.text = "Best time: " + times[1].ToString("0.00");
        //lvl2Text.text = "Best time: " + times[2].ToString("0.00");
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIManager.instance.gameIsFinished = true;
            returnToMenu();
        }
    }

    public void returnToMenu()
    {

       LoadScenelvlManager(LevelsEnum.StartScreen);
    }


    public void LoadScenelvlManager(LevelsEnum levelToLoad)
    {
        SceneManager.LoadScene(levelToLoad.ToString());
    }
}
