using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionCanvas : MonoBehaviour
{
    public GameObject card01;
    
    public void renderCanvasImage01() {
        card01.transform.SetSiblingIndex(0);
    }
    public void renderCanvasImage02()
    {
        card01.transform.SetSiblingIndex(1);
    }

}
