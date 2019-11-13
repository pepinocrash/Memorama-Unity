using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnear_Particula : MonoBehaviour
{
    public GameObject Particula_bien;
    public GameObject Particula_mal;
    // Start is called before the first frame update
    public void spawn_correcta()
    {

        GameObject childObject = Instantiate(Particula_bien, this.transform.position, this.transform.rotation);
        childObject.transform.localScale = new Vector3(10, 10, 10);
        childObject.transform.parent = this.transform;

    }

    public void spawn_incorrecta()
    {

        GameObject childObject = Instantiate(Particula_mal,this.transform.position,this.transform.rotation);
        childObject.transform.localScale = new Vector3(3, 3, 3);
        childObject.transform.parent = this.transform;
    }



}
