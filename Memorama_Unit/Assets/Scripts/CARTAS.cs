using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CARTAS : MonoBehaviour
{
    public List<Texture> cartas_01;
    public List<Texture> cartas_02;
    public List<Texture> cartas_03;
    public List<Texture> cartas_04;
    public GameObject SongManager;
    GameObject Managers;


    // Start is called before the first frame update
    void Start()
    {
        Managers = GameObject.Find("Manager");
        
    }

    // Update is called once per frame


    public void mazo_figuras(GameObject fade)
    {
        fade.GetComponent<Animator>().Play("fade_in");
        fade.GetComponent<Animator>().StopPlayback();
        Managers.GetComponent<GameManager>().acomodo_tarjetas(cartas_01);
        changeMusic();

    }

    public void mazo_numeros(GameObject fade)
    {
        fade.GetComponent<Animator>().Play("fade_in");
        fade.GetComponent<Animator>().StopPlayback();
        Managers.GetComponent<GameManager>().acomodo_tarjetas(cartas_02);
        changeMusic();

    }

    public void mazo_letras(GameObject fade)
    {
        fade.GetComponent<Animator>().Play("fade_in");
        fade.GetComponent<Animator>().StopPlayback();
        Managers.GetComponent<GameManager>().acomodo_tarjetas(cartas_03);
        changeMusic();

    }

    public void mazo_bichos(GameObject fade)
    {
        fade.GetComponent<Animator>().Play("fade_in");
        fade.GetComponent<Animator>().StopPlayback();
        Managers.GetComponent<GameManager>().acomodo_tarjetas(cartas_04);
        changeMusic();

    }

   

    public void RestartLevel(GameObject fade)
    {
        fade.GetComponent<Animator>().Play("regresar_menu");
        fade.GetComponent<Animator>().StopPlayback();
    }

    void changeMusic()
    {
        AudioSource[] Audio = SongManager.GetComponents<AudioSource>();
        Audio[0].Stop();
        Audio[1].Play();
    }

}
