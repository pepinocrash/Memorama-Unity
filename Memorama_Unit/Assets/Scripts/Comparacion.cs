using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comparacion : MonoBehaviour
{
    public GameObject cartas01;
    public GameObject cartas02;
    public Texture text01;
    public Texture text02;
    public int clicks = 0;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int SumaClick(int carta)
    {
        if (clicks < 3)
        {
            clicks++;
            return clicks;
        }
        else
        {
            return 3;
        }

    }

    public bool CompararIguales()
    {
        text01 =  cartas01.GetComponent<Renderer>().material.mainTexture;
        text02= cartas02.GetComponent<Renderer>().material.mainTexture;
        Debug.Log(text01 + "\n"+ text02);

        if (text01 == text02)
        {
            return true;
        }
        else
        {

            StartCoroutine(ExecuteAfterTime(2));
          


            return false;
        }
        
    }

    public void setCarta(GameObject carta)
    {
        if (clicks == 1)
        {
            cartas01 = carta;
        }
        else
        {
            cartas02 = carta;
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {

        yield return new WaitForSeconds(time);
        cartas01.GetComponent<Carta_pre>().PlayFlip_Reverse();
       

        // Code to execute after the delay

    }

}
