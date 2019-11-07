using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDown : MonoBehaviour
{
    GameObject go;
    Comparacion comp;
    public int numeroCarta=0;
    Carta_pre carta;
    void Start()
    {
        carta = GetComponent<Carta_pre>();
       // numeroCarta = carta.numeroCarta;
        go = GameObject.Find("Manager");
        comp = (Comparacion)go.GetComponent(typeof(Comparacion));
    }

    void OnMouseDown()
    {
        comp.SumaClick(numeroCarta);
    }
}

