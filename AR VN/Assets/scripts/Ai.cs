using UnityEngine;

public class Ai:MonoBehaviour
{
    //script de dialogos, sprites y estatus de AI
    public string char_name = "Ai";
    public GameObject Ar_image;
    public  Sprite idle;
    public Sprite smile;
    public Sprite pensativa;
    public Sprite sonrrojada;
    public int Affection_points;
    [HideInInspector] public string d1;
    [HideInInspector] public string d2;
    [HideInInspector] public string d3;

    [HideInInspector] public string d4;
    [HideInInspector] public string d5;
    [HideInInspector] public string d6;
    private void Start()
    {
        d1 = "Salutation, as humans say. My name is AI, and I am programmed to learn the behaviors of the humanity";
        d2 = "Your grades show that you are not a candidate to tutor A";
        d3 = "";

        d4 = "They are in the critical point of their battle plan, looks like the invasion is going to cost a lot of the vanguard's lives";
        d5 = "Play?";
        d6 = "Do humans see war as an action categorized as play?";
    }
}
