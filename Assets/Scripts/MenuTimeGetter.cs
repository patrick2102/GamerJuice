using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuTimeGetter : MonoBehaviour
{
    public TextMeshProUGUI text;
    public int level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (level == 1)
        {
            text.text = "Best time: " + LevelManager.instance.times[1].ToString("0.00");
        }
        if (level == 2)
        {
            text.text = "Best time: " + LevelManager.instance.times[2].ToString("0.00");
        }

    }
}
