using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carta_pre : MonoBehaviour
{
    // Start is called before the first frame update

    public bool tarjeta_vol = false;

    public static int tarjetas_volteadas;



    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == transform.name /*&& tarjetas_volteadas>=2*/)
                {
                    tarjetas_volteadas = tarjetas_volteadas + 1;

                    this.gameObject.GetComponent<Animator>().Play("cartar_voltear");
                    this.gameObject.GetComponent<Animator>().StopPlayback();


                }
            }
        }

    }
}
