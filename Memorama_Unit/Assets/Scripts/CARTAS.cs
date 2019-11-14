﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CARTAS : MonoBehaviour
{
    public List<Texture> cartas_01;
    public List<Texture> cartas_02;
    public List<Texture> cartas_03;
    public List<Texture> cartas_04;

    GameObject Managers;
    public GameObject Menu;


    // Start is called before the first frame update
    void Start()
    {
        Managers = GameObject.Find("Manager");
    }

    // Update is called once per frame


    public void mazo_figuras()
    {
        Managers.GetComponent<GameManager>().acomodo_tarjetas(cartas_01);
        Menu.SetActive(false);
    }

    public void mazo_numeros()
    {
        Managers.GetComponent<GameManager>().acomodo_tarjetas(cartas_02);
        Menu.SetActive(false);

    }

    public void mazo_letras()
    {
        Managers.GetComponent<GameManager>().acomodo_tarjetas(cartas_03);
        Menu.SetActive(false);

    }

    public void mazo_bichos()
    {
        Managers.GetComponent<GameManager>().acomodo_tarjetas(cartas_04);
        Menu.SetActive(false);

    }

}
