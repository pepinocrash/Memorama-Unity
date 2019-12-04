using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Carta_pre : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool Seleccionadas = true;

    public static int tarjetas_volteadas;

    public static int pares = 0;
    public static int fallos = 0;
    public Text canvasPares;

    GameObject go;
    Comparacion comp;

    GameObject particula;

    public AudioSource voltear;
    public AudioSource Finish;

    public Animator anim;
   

    void Start()
    {
        anim = this.GetComponent<Animator>();
        go = GameObject.Find("Manager");
        particula = GameObject.Find("Particula");
        comp = (Comparacion)go.GetComponent(typeof(Comparacion));
        voltear = this.GetComponent<AudioSource>();
        Finish = this.GetComponent<AudioSource>();
        voltear.clip = go.GetComponent<GameManager>().pick; 
        Finish.clip = go.GetComponent<GameManager>().fin; 
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        //    RaycastHit hit;
        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        if (hit.transform.name == transform.name/* && tarjetas_volteadas <= 2*/ && Seleccionadas == false)
        //        {
        //            tarjetas_volteadas = tarjetas_volteadas + 1;

        //            var card = hit.collider.GetComponent<Carta_pre>();
        //            if (card != null)
        //            {
        //                int click = card.comp.SumaClick(0);
        //                if (click <= 2)
        //                {

        //                    card.PlayFlip();
        //                    card.comp.setCarta(gameObject);



        //                }
        //                if (click == 2)
        //                {
        //                    Seleccionadas = true;
        //                    bool equals = card.comp.CompararIguales();

        //                    if (equals)
        //                    {

        //                        //animacion destruccion
        //                        card.comp.clicks = 0;
        //                        particula.GetComponent<Spawnear_Particula>().spawn_correcta();
        //                        StartCoroutine(DestroyAfterTime(2));
        //                        StartCoroutine(activarbool(5));



        //                    }
        //                    else
        //                    {
        //                        //animacion de volteo
        //                        card.comp.clicks = 0;
        //                        StartCoroutine(ExecuteAfterTime(2));
        //                        StartCoroutine(activarbool(5));



        //                    }

        //                }



        //            }
        //        }
        //    }
        }


    

    public void Seleccion()
    {

        Seleccionadas = false;
    }

    public void PlayFlip()
    {
        voltear.clip = go.GetComponent<GameManager>().pick;
        voltear.Play();
        anim.gameObject.GetComponent<Animator>().Rebind();
        anim.SetFloat("carta_voltear", 1);
        anim.gameObject.GetComponent<Animator>().Play("cartar_voltear");
        anim.gameObject.GetComponent<Animator>().StopPlayback();
        

    }

    public void PlayFlip_Reverse()
    {
        //anim.gameObject.GetComponent<Animator>().Rebind();
        comp.cartas01.gameObject.GetComponent<Animator>().SetFloat("carta_voltear", -1);
        comp.cartas02.gameObject.GetComponent<Animator>().SetFloat("carta_voltear", -1);
        comp.cartas01.gameObject.GetComponent<Animator>().Play("cartar_voltear");
        comp.cartas01.gameObject.GetComponent<Animator>().StopPlayback();
        comp.cartas02.gameObject.GetComponent<Animator>().Play("cartar_voltear");
        comp.cartas02.gameObject.GetComponent<Animator>().StopPlayback();


    }

    public void ocultar()
    {
        //anim.gameObject.GetComponent<Animator>().Rebind();
        comp.cartas01.gameObject.GetComponent<Animator>().Play("adios_tarjeta");
        comp.cartas01.gameObject.GetComponent<Animator>().StopPlayback();
        comp.cartas02.gameObject.GetComponent<Animator>().Play("adios_tarjeta");
        comp.cartas02.gameObject.GetComponent<Animator>().StopPlayback();


    }

    public void destruir()
    {
        Destroy(comp.cartas01.transform.parent);
        Destroy(comp.cartas02.transform.parent);
        comp.cartas01 = null;
        comp.cartas02 = null;
        Seleccionadas = false;
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && Seleccionadas==false)
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
                        Seleccionadas = true;
                        bool equals = card.comp.CompararIguales();
                       
                        if (equals)
                        {
                           
                            //animacion destruccion
                            card.comp.clicks = 0;
                            StartCoroutine(DestroyAfterTime(2));
                            StartCoroutine(activarbool(5));
                            pares++;
                            canvasPares.text = pares + "/6";

                            if (pares >= 6)
                            {
                                //Reproducir sonido de victoria y poner imagen de estrellas
                                Finish.Play();
                            }


                        }
                        else
                        {
                            //animacion de volteo
                            card.comp.clicks = 0;
                            StartCoroutine(ExecuteAfterTime(2));
                            StartCoroutine(activarbool(5));



                        }
                    }


                }
            }
        }

    }

    void OnTouchDown()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == transform.name  && tarjetas_volteadas <= 2 && Seleccionadas == false)
                {
                    tarjetas_volteadas = tarjetas_volteadas + 1;

                    var card = hit.collider.GetComponent<Carta_pre>();
                    if (card != null)
                    {
                        int click = card.comp.SumaClick(0);
                        if (click <= 2)
                        {

                            card.PlayFlip();
                            card.comp.setCarta(gameObject);



                        }
                        if (click == 2)
                        {
                            Seleccionadas = true;
                            bool equals = card.comp.CompararIguales();

                            if (equals)
                            {

                                //animacion destruccion
                                card.comp.clicks = 0;
                                //particula.GetComponent<Spawnear_Particula>().spawn_correcta();
                                StartCoroutine(DestroyAfterTime(2));
                                StartCoroutine(activarbool(5));
                                pares++;
                                canvasPares.text = pares + "/6";
                                if (pares>=6)
                                {
                                    //Reproducir sonido de victoria y poner imagen de estrellas
                                    Finish.Play();
                                }



                            }
                            else
                            {
                                //animacion de volteo
                                fallos++;
                                card.comp.clicks = 0;
                                StartCoroutine(ExecuteAfterTime(2));
                                StartCoroutine(activarbool(5));



                            }

                        }



                    }
                }
            }
        }
        }


    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        voltear.clip = go.GetComponent<GameManager>().lose;
        voltear.Play();
        particula.GetComponent<Spawnear_Particula>().spawn_incorrecta();

        comp.cartas01 = null;
        comp.cartas02 = null;
        

        // Code to execute after the delay

    }

    IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        voltear.clip = go.GetComponent<GameManager>().win;
        voltear.Play();
        particula.GetComponent<Spawnear_Particula>().spawn_correcta();
        ocultar();
        //Destroy(comp.cartas01);
        //Destroy(comp.cartas02);
        //comp.cartas01 = null;
        //comp.cartas02 = null;

        //Seleccionadas = false;



    }

    IEnumerator activarbool(float time)
    {
        yield return new WaitForSeconds(time);
       
        Seleccionadas = false;

    }



}

