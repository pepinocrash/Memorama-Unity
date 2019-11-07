using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Texture> cartas;

    public GameObject[] carta_scene;

    int cantidad_maxima=4;

    // Start is called before the first frame update
    void Start()
    {
        carta_scene = GameObject.FindGameObjectsWithTag("carta");

        for(int i=0; i<carta_scene.Length; i++)
        {
            int numero_list = Random.Range(0, cantidad_maxima);
            Debug.Log(numero_list);

            Material nuevo = carta_scene[i].transform.GetChild(0).GetComponent<Renderer>().material;

            nuevo.mainTexture= cartas[numero_list];

            cartas.Remove(cartas[numero_list]);

            cantidad_maxima = cantidad_maxima - 1;

            carta_scene[i].transform.GetChild(0).GetComponent<Renderer>().material = nuevo;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
