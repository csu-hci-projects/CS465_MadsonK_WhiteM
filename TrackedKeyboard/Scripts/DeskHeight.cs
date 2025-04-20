using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskHeight : MonoBehaviour
{
    public GameObject desk;
    public GameObject keyboard;
    public GameObject textCanvas;

    private Vector3 increment = new Vector3 (0, 0.01f, 0);

    public void adjustUp()
    {
        desk.transform.position += increment;
        keyboard.transform.position += increment;
        textCanvas.transform.position += increment;
    }
    public void adjustDown()
    {
        desk.transform .position -= increment;
        keyboard.transform .position -= increment;  
        textCanvas.transform .position -= increment;
    }
}
