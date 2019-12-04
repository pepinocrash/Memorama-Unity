using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    List<Texture> cartas;

    public GameObject[] carta_scene;

    int cantidad_maxima=12;

    public AudioClip pick;
    public AudioClip win;
    public AudioClip lose;

    // Start is called before the first frame update

    public void acomodo_tarjetas(List<Texture> cartas_sel)
    {
        carta_scene = GameObject.FindGameObjectsWithTag("carta");
        cartas = cartas_sel;

        for (int i = 0; i < carta_scene.Length; i++)
        {
            int numero_list = Random.Range(0, cantidad_maxima);
            Debug.Log(numero_list);

            Material nuevo = carta_scene[i].transform.GetChild(0).GetComponent<Renderer>().material;

            nuevo.mainTexture = cartas[numero_list];

            cartas.Remove(cartas[numero_list]);

            cantidad_maxima = cantidad_maxima - 1;

            carta_scene[i].transform.GetChild(0).GetComponent<Renderer>().material = nuevo;
        }


    }



}
