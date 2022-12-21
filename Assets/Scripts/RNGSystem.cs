using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RNGSystem : MonoBehaviour
{
    /*
     A value of 0 disables the RNG
     for the weightedlist 0 returns the middle enum as it is the neutral value, increasing the weight increases the chance of the better option while decreasing the chance of the worse options
     for TF a value of 0 always returns false, increasing the value increases the chance of returning true
     */
    public int weight;
    public int TF;

    public List<RNG> weightedList = new List<RNG>();
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        generateNewList();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.A))
        {
            generateNewList();
        }
        if(timer > 0.5)
        {
            timer = 0;
            Debug.Log(TFrng());
        }
        
    }

    public void generateNewList()
    {
        weightedList.Clear();
        for (int i = 0; i < 20 - (2*(weight-1)); i++)
        {
            weightedList.Add(RNG.Terrible);
        }
        for (int i = 0; i < 20 - (weight-1); i++)
        {
            weightedList.Add(RNG.Bad);
        }
        for (int i = 0; i < 20; i++)
        {
            weightedList.Add(RNG.Middle);
        }
        for (int i = 0; i < 20+(weight-1); i++)
        {
            weightedList.Add(RNG.Good);
        }
        for (int i = 0; i < 20+(2*(weight-1)); i++)
        {
            weightedList.Add(RNG.Amazing);
        }
    }

    public bool TFrng()
    {
        if (TF > 100)
        {
            TF = 100;
        }
        if (TF == 0)
        {
            return false;
        } else
        {
            var value = Random.Range(1, 100);
            if (value < TF)
            {
                return true;
            }
            else return false;
        }
    }
    
    public RNG getRNG()
    {
        if (weight == 0)
        {
            return RNG.Middle;
        } else
        {
            int indexer = Random.Range(0, weightedList.Count - 1);
            var value = weightedList[indexer];
            return value;
        }
    }


}

public enum RNG
{
    Terrible,
    Bad,
    Middle,
    Good,
    Amazing
}