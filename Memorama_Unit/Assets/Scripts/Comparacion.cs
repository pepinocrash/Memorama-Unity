﻿using System.Collections;
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

    public int SumaClick()
    {
        if (clicks < 1)
        {
            clicks++;
            return clicks;
        }
        else
        {
            //voltear tarjeta
            return clicks;
        }
    }
}