using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VictoryScreenTime : MonoBehaviour
{

    public TextMeshProUGUI victoryscreentime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        victoryscreentime.text = "You beat the level in: " + LevelManager.instance.times[0].ToString("0.00") + "\n Press ESC to return to menu";
    }
}
