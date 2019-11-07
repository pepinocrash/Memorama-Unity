using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comparacion : MonoBehaviour
{
    public GameObject[] cartas;
    public int clicks = 0;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int SumaClick(int carta)
    {
        if (clicks < 3)
        {
            clicks++;
            return clicks;
        }
        else
        {
            return 3;
        }

    }
}
