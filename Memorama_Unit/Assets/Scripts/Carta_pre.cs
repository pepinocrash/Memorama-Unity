using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carta_pre : MonoBehaviour
{
    // Start is called before the first frame update

    public bool tarjeta_vol = false;

    public static int tarjetas_volteadas;

    GameObject go;
    Comparacion comp;

    Animator anim;

    void Start()
    {
        anim = this.GetComponent<Animator>();
        go = GameObject.Find("Manager");
        comp = (Comparacion)go.GetComponent(typeof(Comparacion));
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

                        card.comp.SumaClick(0);
                        card.PlayFlip();
                        
                    }



                }
            }
        }



       /* if (Input.GetMouseButtonDown(0))
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
                    card.comp.SumaClick(0);
                    card.PlayFlip();

                    
                }
            }
        }*/
    }

    public void PlayFlip()
    {
        anim.gameObject.GetComponent<Animator>().Play("cartar_voltear");
        anim.gameObject.GetComponent<Animator>().StopPlayback();
    }

    void OnMouseDown()
    {
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
                    int click = card.comp.SumaClick(0);
                    if (click <= 2)
                    {
                        card.PlayFlip();
                        card.comp.setCarta(gameObject);



                    }
                    if (click==2)
                    {
                       bool equals = card.comp.CompararIguales();
                        if (equals)
                        {
                            //animacion destruccion
                            Destroy(card.comp.cartas01);
                            Destroy(card.comp.cartas02);
                            card.comp.clicks = 0;
                        }
                        else
                        {
                            //animacion de volteo
                            card.comp.clicks = 0;
                            card.comp.cartas01 = null;
                            card.comp.cartas02 = null;

                        }
                    }


                }
            }
        }

    }

}

