using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum evento { I_1,I_2,I_3,I_4,D1_1,D1_2,D1_h,D1_a,D1_y,end};//IDs para los eventps
public enum Decition { top,center_top,center_bottom,bottom };//IDs para los botones de las deciciones

public class eventController : MonoBehaviour
{
    public int index_evento;
    public Canvas VN_canvas;
    public Canvas AR_canvas;
    public Text textBox;
    public Text nameBox;
    public Text Scan_name;
    public Button textbox_button;
    public Image char_left;
    public Image char_center;
    public Image char_right;
    public Image background;
    public GameObject top_decition;
    public GameObject center_top_decition;
    public GameObject center_bottom_decition;
    public GameObject bottom_decition;
    public deactivate_image image_cont;//controlador de targets de vuforia
    public Mc mc;
    public Ai ai;
    public Yui yui;
    public Homura homura;
    public Sprite nullSprite;
    public Sprite Background;
    public string cardName;
    public Backgrounds BG;
    public fade fader;

    public Decition decition;
    public evento nombre_evento;

    // Start is called before the first frame update
    void Start()
    {
        index_evento = 0;
        nullCharacters();
        disableDecitions();
        ActualizarEventos();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0)) {
            index_evento++; //DEBUG: pasar al siguiente evento
        }*/
    }

    //mostrar dialogo y la persona que lo dice en pantalla
    void showDialogue(string name,string dialogue) {
        textBox.text = dialogue;
        nameBox.text = name;
    }

    //escojer uno de los espacios de UI para los personajes, activarlo y asignarle un sprite
    void showCharacter(Image character, Sprite sprite)
    {
        if (!character.enabled) {
            character.enabled = true;
        }
        character.sprite = sprite;
    }

    //desactivar a todos los personajes
    void nullCharacters() {
        char_left.enabled=false;
        char_right.enabled=false;
        char_center.enabled = false;
    }

    //activar un botón de decición y asignarle un texto y un target de Vuforia
    void setDecition(GameObject decition, string text,string _cardName) {
        decition.SetActive(true);
        decition.GetComponentInChildren<Text>().text = text;
        decition.GetComponent<button_scr>().character = _cardName;
        deactivateTextBoxTouch();
    }

    //desactivar todos los botones de deciciones y activar el touch en el cuadro de texto
    void disableDecitions() {
        top_decition.SetActive(false);
        center_top_decition.SetActive(false);
        center_bottom_decition.SetActive(false);
        bottom_decition.SetActive(false);
        activateTextBoxTouch();
    }

    public void addIndex() {
        index_evento++;
    }

    //activar/desactivar touch en cuadro de texto
    public void deactivateTextBoxTouch() {
        textbox_button.enabled = false;
    }

    public void activateTextBoxTouch()
    {
        textbox_button.enabled = true;
    }

    //mostrar lo que la cámara del dispositivo está viendo
    public void activateARScan() {
        VN_canvas.gameObject.SetActive(false);
        AR_canvas.gameObject.SetActive(true);
    }

    //tapar lo que la cámara del dispositivo está viendo
    public void deactivateARScan()
    {
        VN_canvas.gameObject.SetActive(true);
        AR_canvas.gameObject.SetActive(false);
    }

    //asignar ID de dicición cuando se aprieta un botón
    public void chooseDecition(int index) {
        if (index == 0)
        {
            decition = Decition.top;
        }
        if (index == 1)
        {
            decition = Decition.center_top;
        }
        if (index == 2)
        {
            decition = Decition.center_bottom;
        }
        if (index == 3)
        {
            decition = Decition.bottom;
        }
        image_cont.activateImage(cardName);
    }

    //asignar sprite de background con una transición
    public void SetBackground(Sprite bg)
    {
        Background = bg;
        fader.fade_BG();
        Invoke("change_BG", 0.3f);
    }

    public void change_BG() {
        background.sprite = Background;
    }

    //acciones que ocurren cuando se confirma una decicion depandiendo del evento enel que el jugador se encuentre
    public void decide() {
        if (nombre_evento == evento.I_3) {
           if (decition == Decition.top) {
                index_evento = 8;
            }
        }
        if (nombre_evento == evento.D1_1)
        {
            if (decition == Decition.top)
            {
                index_evento = 0;
                nombre_evento = evento.D1_h;
            }
            if (decition == Decition.center_top)
            {
                index_evento = 0;
                nombre_evento = evento.D1_a;
            }
            if (decition == Decition.center_bottom)
            {
                index_evento = 0;
                nombre_evento = evento.D1_y;
            }
        }

        disableDecitions();//desactivar los botones de decición
        ActualizarEventos();
    }

    //detalles de los eventos y el estado en el que se encuentra el evento
    //el index de evento aumenta cuando el jugador aprieta la caja de texto o los botones
    public void ActualizarEventos() {

        if (nombre_evento == evento.I_1)
        {
            if (index_evento == 0)
            {
                SetBackground(BG.pitch_black);
                showDialogue("", mc.d1);
                return;
            }
            index_evento = 0;
            nombre_evento = evento.I_2;
        }
        if (nombre_evento == evento.I_2)
        {
            if (index_evento == 0) {
                SetBackground(BG.class_room);
                showDialogue("Teacher", "Everyone!, say hello to our new classmate, she is joininng us in the middle of the year, so please help her to catch up in her studies");
                return;
            }

            if (index_evento == 1)
            {
                showDialogue("Teacher", "Any way, anything you want to tell us about you?");
                return;
            }

            if (index_evento == 2)
            {
                showDialogue(mc.char_name, mc.d2);
                return;
            }
            if (index_evento == 3)
            {
                showDialogue("", mc.d3);
                return;
            }

            if (index_evento == 4)
            {
                showDialogue("classmates", "...");
                return;
            }

            if (index_evento == 5)
            {
                showDialogue("classmates", "......");
                return;
            }

            if (index_evento == 6)
            {
                showDialogue("classmates", "Woah... Such a pretty girl... Hope she sits with me at lunch...");
                return;
            }

            if (index_evento == 7)
            {
                showDialogue("Teacher", "*fake cof cof* well... you can sit over there");
                return;
            }
            index_evento = 0;
            nombre_evento = evento.I_3;
        }
        if (nombre_evento == evento.I_3){
            if (index_evento == 0)
            {
                showDialogue("", "*After class*");
                return;
            }

            if (index_evento == 1)
            {
                showDialogue("White haired girl", ai.d1);
                return;
            }
            if (index_evento == 2)
            {
                showCharacter(char_center, ai.idle);
                showDialogue(ai.char_name, "...");
                return;
            }

            if (index_evento == 3)
            {
                showDialogue("", mc.d4);
                return;
            }

            if (index_evento == 4)
            {
                showCharacter(char_center, ai.pensativa);
                showDialogue(ai.char_name, "......");
                return;
            }

            if (index_evento == 5)
            {
                showDialogue(ai.char_name, ".........");
                return;
            }

            if (index_evento == 6)
            {
                showDialogue("", mc.d5);
                setDecition(top_decition, "touch forehead to see if she is alive(scan)", ai.char_name);
                setDecition(bottom_decition, "...", ai.char_name);
                return;
            }

            if (index_evento == 8)
            {
                showDialogue("", mc.d6);
                disableDecitions();
                return;
            }

            if (index_evento == 9)
            {
                showCharacter(char_center, ai.sonrrojada);
                showDialogue(ai.char_name, "...!!!");
                return;
            }
            disableDecitions();
            index_evento = 0;
            nombre_evento = evento.I_4;
        }
        if (nombre_evento == evento.I_4)
        {
            if (index_evento == 0)
            {
                showCharacter(char_center, ai.idle);
                showDialogue("short black hair girl", yui.d1);
                return;
            }
            if (index_evento == 1)
            {
                showCharacter(char_left, yui.Smile);
                showDialogue(yui.char_name, yui.d2);
                return;
            }
            if (index_evento == 2)
            {
                showDialogue("brown haired girl", homura.d1);
                return;
            }
            if (index_evento == 3)
            {
                showCharacter(char_right, homura.shock);
                showDialogue(homura.char_name, homura.d2);
                return;
            }
            if (index_evento == 4)
            {
                showCharacter(char_right, homura.idle);
                showCharacter(char_left, yui.idle);
                showDialogue(yui.char_name, yui.d3);
                return;
            }
            if (index_evento == 5)
            {
                showCharacter(char_center, ai.pensativa);
                showDialogue(ai.char_name, ai.d2);
                return;
            }
            if (index_evento == 6)
            {
                showDialogue(yui.char_name, yui.d4);
                return;
            }
            if (index_evento == 7)
            {
                showCharacter(char_right, homura.sad);
                showDialogue(homura.char_name, homura.d3);
                return;
            }
            if (index_evento == 8)
            {
                showDialogue("", mc.d7);
                return;
            }
            disableDecitions();
            index_evento = 0;
            nombre_evento = evento.D1_1;
        }
        if (nombre_evento == evento.D1_1)
        {
            if (index_evento == 0)
            {
                nullCharacters();
                SetBackground(BG.pitch_black);
                showDialogue("", "*evening*");
                return;
            }
            if (index_evento == 1)
            {
                SetBackground(BG.school_hall);
                showDialogue("", mc.d8);
                return;
            }
            if (index_evento == 2)
            {
                showDialogue("", mc.d8);
                setDecition(top_decition, "library(scan)",homura.char_name);
                setDecition(center_top_decition, "garden(scan)", ai.char_name);
                setDecition(center_bottom_decition, "running track(scan)", yui.char_name);
                setDecition(bottom_decition, "investigate", ai.char_name);
                return;
            }
            if (index_evento == 3) {
                nombre_evento = evento.D1_2;
            }
            index_evento = 0;
        }
        if (nombre_evento == evento.D1_2)
        {
            activateTextBoxTouch();
            disableDecitions();
            if (index_evento == 0)
            {
                nullCharacters();
                mc.Investigation_points++;
                SetBackground(BG.Sec_building);
                showDialogue("", mc.d9);
                return;
            }
            if (index_evento == 1)
            {
                showDialogue("", mc.d10);
                return;
            }
            nombre_evento = evento.end;
            index_evento = 0;
        }
        if (nombre_evento == evento.D1_a)
        {
            if (index_evento == 0)
            {
                nullCharacters();
                ai.Affection_points++;
                SetBackground(BG.garden);
                showDialogue("", mc.d11);
                return;
            }
            if (index_evento == 1)
            {
                showDialogue(mc.char_name, mc.d12);
                showCharacter(char_center, ai.pensativa);
                return;
            }
            if (index_evento == 2)
            {
                showDialogue(ai.char_name, "...");
                return;
            }
            if (index_evento == 3)
            {
                showDialogue(ai.char_name, "......!");
                return;
            }
            if (index_evento == 4)
            {
                showCharacter(char_center, ai.idle);
                showDialogue(ai.char_name, ai.d4);
                return;
            }
            if (index_evento == 5)
            {
                showDialogue(mc.char_name, mc.d13);
                return;
            }
            if (index_evento == 6)
            {
                showDialogue(ai.char_name, ai.d5);
                return;
            }
            if (index_evento == 7)
            {
                showCharacter(char_center, ai.pensativa);
                showDialogue(ai.char_name, "...?");
                return;
            }
            if (index_evento == 8)
            {
                showDialogue(ai.char_name, ai.d6);
                return;
            }
            if (index_evento == 9)
            {
                showDialogue(mc.char_name, mc.d14);
                return;
            }
            if (index_evento == 10)
            {
                showDialogue("", mc.d15);
                return;
            }
            nombre_evento = evento.end;
            index_evento = 0;
        }
        if (nombre_evento == evento.D1_y)
        {
            if (index_evento == 0)
            {
                nullCharacters();
                yui.Affection_points++;
                SetBackground(BG.runinng_track);
                showDialogue("", mc.d16);
                return;
            }
            if (index_evento == 1)
            {
                showDialogue(yui.char_name, yui.d5);
                return;
            }
            if (index_evento == 2)
            {
                showCharacter(char_center, yui.SmileS);
                showDialogue(mc.char_name, mc.d17);
                return;
            }
            if (index_evento == 3)
            {
                showDialogue(yui.char_name, yui.d6);
                return;
            }
            if (index_evento == 4)
            {
                showDialogue(mc.char_name, mc.d18);
                return;
            }
            if (index_evento == 5)
            {
                showCharacter(char_center, yui.idleS);
                showDialogue(mc.char_name, mc.d19);
                return;
            }
            if (index_evento == 6)
            {
                showDialogue("", mc.d20);
                return;
            }
            nombre_evento = evento.end;
            index_evento = 0;
        }
        if (nombre_evento == evento.D1_h)
        {
            if (index_evento == 0)
            {
                nullCharacters();
                homura.Affection_points++;
                SetBackground(BG.pitch_black);
                showDialogue("", mc.d21);
                return;
            }
            if (index_evento == 1)
            {
                SetBackground(BG.library);
                showDialogue("", mc.d22);
                return;
            }
            if (index_evento == 2)
            {
                showDialogue(mc.char_name, mc.d23);
                return;
            }
            if (index_evento == 3)
            {
                showCharacter(char_center, homura.idle);
                showDialogue(homura.char_name, homura.d4);
                return;
            }
            if (index_evento == 4)
            {
                showCharacter(char_center, homura.sad);
                showDialogue(homura.char_name, homura.d5);
                return;
            }
            if (index_evento == 5)
            {
                showDialogue("", mc.d24);
                return;
            }
            if (index_evento == 6)
            {
                showDialogue(homura.char_name, homura.d6);
                return;
            }
            if (index_evento == 7)
            {
                showDialogue("", mc.d25);
                return;
            }
            if (index_evento == 8)
            {
                showDialogue(mc.char_name, mc.d26);
                return;
            }
            if (index_evento == 9)
            {
                showCharacter(char_center, homura.idle);
                showDialogue(homura.char_name, homura.d7);
                return;
            }
            if (index_evento == 10)
            {
                showCharacter(char_center, homura.smile);
                showDialogue(homura.char_name, homura.d8);
                return;
            }
            if (index_evento == 11)
            {
                showDialogue("", mc.d27);
                return;
            }
            if (index_evento == 12)
            {
                showDialogue("", mc.d28);
                return;
            }
            nombre_evento = evento.end;
            index_evento = 0;
        }

        if (nombre_evento == evento.end)
        {
            if (index_evento == 0)
            {
                nullCharacters();
                deactivateTextBoxTouch();
                SetBackground(BG.pitch_black);
                showDialogue("Developer", "this is the end of the demo thank you for playing, this demo was developed by: José María Beristain García. Song: Upbeat Theme Loop by MrtheNoronha");
                return;
            }
        }//fin del demo
    }

}
