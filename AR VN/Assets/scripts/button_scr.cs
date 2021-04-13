using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_scr : MonoBehaviour
{
    public string character;
    public eventController EC;
    // Start is called before the first frame update

    //asignar nombre del target de personaje de Vuforia
    public void setChar() {
        EC.cardName = character;
        EC.Scan_name.text = "Scan " + character;
    }
}
