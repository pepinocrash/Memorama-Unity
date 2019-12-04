using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CARTAS : MonoBehaviour
{
    public List<Texture> cartas_01;
    public List<Texture> cartas_02;
    public List<Texture> cartas_03;
    public List<Texture> cartas_04;
    GameObject TextPares;
    GameObject Managers;


    // Start is called before the first frame update
    void Start()
    {
        Managers = GameObject.Find("Manager");
        TextPares = GameObject.FindWithTag("TextoPares");
    }

    // Update is called once per frame


    public void mazo_figuras(GameObject fade)
    {
        fade.GetComponent<Animator>().Play("fade_in");
        fade.GetComponent<Animator>().StopPlayback();
        Managers.GetComponent<GameManager>().acomodo_tarjetas(cartas_01);
       
    }

    public void mazo_numeros(GameObject fade)
    {
        fade.GetComponent<Animator>().Play("fade_in");
        fade.GetComponent<Animator>().StopPlayback();
        Managers.GetComponent<GameManager>().acomodo_tarjetas(cartas_02);
       

    }

    public void mazo_letras(GameObject fade)
    {
        fade.GetComponent<Animator>().Play("fade_in");
        fade.GetComponent<Animator>().StopPlayback();
        Managers.GetComponent<GameManager>().acomodo_tarjetas(cartas_03);
      

    }

    public void mazo_bichos(GameObject fade)
    {
        fade.GetComponent<Animator>().Play("fade_in");
        fade.GetComponent<Animator>().StopPlayback();
        Managers.GetComponent<GameManager>().acomodo_tarjetas(cartas_04);
       

    }

    public void ShowStats()
    {
        TextPares.SetActive(true);
    }

    public void RestartLevel()
    {
        Application.LoadLevel("main");
    }

}
