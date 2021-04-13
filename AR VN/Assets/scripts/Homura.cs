using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homura : MonoBehaviour
{
    //script de dialogos, sprites y estatus de Homura
    public string char_name = "Homura";
    public GameObject Ar_image;
    public Sprite idle;
    public Sprite sad;
    public Sprite smile;
    public Sprite shock;
    public int Affection_points;
    [HideInInspector] public string d1;
    [HideInInspector] public string d2;
    [HideInInspector] public string d3;
    [HideInInspector] public string d4;
    [HideInInspector] public string d5;
    [HideInInspector] public string d6;
    [HideInInspector] public string d7;
    [HideInInspector] public string d8;
    private void Start()
    {
        d1 = "YUI! If the teacher hears you talking like that, she is going to take you with the principal for talking like a person from a gang";
        d2 = "PARDON ME! How rude I am for not introducing myself, My name is Homura, I will be glad to help you with your studies";
        d3 = "I will not say that you don't have other types of intelligence, but, you should care more about your homework and...";

        d4 = "Hello again, of course, take a sit and feel free to ask anything";
        d5 = "Talking about questions, I have one about you that has been bothering me since I saw you...";
        d6 = "Why did you change schools in mid-year? If it isn't impertinent to ask";
        d7 = "I see, well, you better begin with your homework if you want to end before the graduation";
        d8 = "Tehe~";

    }
}
