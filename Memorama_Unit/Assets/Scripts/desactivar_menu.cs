using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desactivar_menu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Menu;
    public GameObject[] carta_scene;
    public GameObject cameraScene;
    GameObject TextPares;
    void Start()
    {

        carta_scene = GameObject.FindGameObjectsWithTag("carta");
        cameraScene = GameObject.FindWithTag("MainCamera");
        TextPares = GameObject.FindWithTag("TextoPares");


    }

    // Update is called once per frame
    void delete_menu()
    {
        Menu.SetActive(false);
        carta_scene[0].transform.GetChild(0).GetComponent<Carta_pre>().Seleccion();

    }

    void playCameraAnim()
    {
        cameraScene.GetComponent<Animator>().Play("CamerAnim");
        cameraScene.GetComponent<Animator>().StopPlayback();

    }

    public void ShowStats()
    {
        TextPares.SetActive(true);
    }
}
