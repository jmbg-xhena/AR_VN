using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yui : MonoBehaviour
{
    //script de dialogos, sprites y estatus de Yui
    public string char_name = "Yui";
    public GameObject Ar_image;
    public Sprite idle;
    public Sprite Angry;
    public Sprite Anoyed;
    public Sprite Smile;
    public Sprite idleS;
    public Sprite AngryS;
    public Sprite AnoyedS;
    public Sprite SmileS;
    public int Affection_points;
    [HideInInspector] public string d1;
    [HideInInspector] public string d2;
    [HideInInspector] public string d3;
    [HideInInspector] public string d4;
    [HideInInspector] public string d5;
    [HideInInspector] public string d6;
    private void Start()
    {
        d1 = "Hey, don't take to serious that robot freak'o over there, she is just passes out sometimes and observes people like a stalker";
        d2 = "The name is Yui, nice to meet you new gal'";
        d3 = "I would also offer help to new gal' but my brain is too much to be understood";
        d4 = "As I said, too much for this ol' education system";

        d5 = "yo! What are you doin' here?";
        d6 = "yup, doing some laps to warm up, wanna' join me? I'll be gentle with you, maybe";
    }
}
