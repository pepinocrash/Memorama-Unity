using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDown : MonoBehaviour
{
    GameObject go;
    Comparacion comp;
    void Start()
    {
        go = GameObject.Find("Manager");
        comp = (Comparacion)go.GetComponent(typeof(Comparacion));
    }

    void OnMouseDown()
    {
        comp.SumaClick();
    }
}

