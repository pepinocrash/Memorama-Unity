using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carta_pre : MonoBehaviour
{
    // Start is called before the first frame update

    public bool tarjeta_vol = false;

    public static int tarjetas_volteadas;

    Animator anim;

    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == transform.name && tarjetas_volteadas<=2)
                {
                    tarjetas_volteadas = tarjetas_volteadas + 1;

                    var card = hit.collider.GetComponent<Carta_pre>();
                    if (card != null)
                    {
                        //we hit a card!
                        card.PlayFlip();
                    }



                }
            }
        }



        if (Input.GetMouseButtonDown(0))
        {
            //we should only do the physics test if the mouse is down...
            //why do an expensive raycast if it doesn't matter?

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                var card = hit.collider.GetComponent<Carta_pre>();
                if (card != null)
                {
                    //we hit a card!
                    card.PlayFlip();
                }
            }
        }
    }

    public void PlayFlip()
    {
        anim.gameObject.GetComponent<Animator>().Play("cartar_voltear");
        anim.gameObject.GetComponent<Animator>().StopPlayback();
    }

}

