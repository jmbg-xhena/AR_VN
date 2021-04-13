using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deactivate_image : MonoBehaviour
{
    public GameObject[] imagenes;
    public GameObject AI_image;
    public GameObject Homura_image;
    public GameObject Yui_image;
    // Start is called before the first frame update
    void Awake()
    {
        imagenes = new GameObject[gameObject.transform.childCount];
        //obtener los target de Vuforia y descativarlos
        for (int i = 0; i < imagenes.Length; ++i)
        {
            imagenes[i] = transform.GetChild(i).gameObject;
            imagenes[i].GetComponent<Vuforia.ImageTargetBehaviour>().enabled = false;
            imagenes[i].GetComponent<DefaultTrackableEventHandler>().enabled = false;
        }
    }

    // Desactivar todos los targets
    public void deactivateImages() {
        for (int i = 0; i < imagenes.Length; i++) {
            imagenes[i].GetComponent<Vuforia.ImageTargetBehaviour>().enabled = false;
            imagenes[i].GetComponent<DefaultTrackableEventHandler>().enabled = false;
        }
    }

    // activar todos los targets
    public void activateImages()
    {
        for (int i = 0; i < imagenes.Length; i++)
        {
            imagenes[i].GetComponent<Vuforia.ImageTargetBehaviour>().enabled = true;
            imagenes[i].GetComponent<DefaultTrackableEventHandler>().enabled = true;
        }
    }

    //activar target específico
    public void activateImage(string name)
    {
        GameObject character=null;
        if (name == "Ai") {
            character = AI_image;
        }
        if (name == "Homura")
        {
            character = Homura_image;
        }
        if (name == "Yui")
        {
            character = Yui_image;
        }
        character.GetComponent<Vuforia.ImageTargetBehaviour>().enabled = true;
        character.GetComponent<DefaultTrackableEventHandler>().enabled = true;
    }

}
