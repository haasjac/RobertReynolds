using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {

    public static Dialogue S;

    [HideInInspector]
    public Text text;
    [HideInInspector]
    public Image background;
    [HideInInspector]
    public Image face;
    [HideInInspector]
    public GameObject buttons;
    [HideInInspector]
    public GameObject textTop;
    [HideInInspector]
    public GameObject textBottom;
    [HideInInspector]
    public GameObject textContinue;
    public Color not_answered = new Color(90.0f/255, 90.0f/255, 90.0f/255f, 1);
    public Color answered = Color.black;
    public Sprite player_face;
    public Sprite question_mark;

    public void init() {
        S = this;
        
        text = GetComponentInChildren<Text>();
        background = GetComponentsInChildren<Image>()[0];
        face = GetComponentsInChildren<Image>()[1];

        buttons = text.transform.FindChild("Buttons").gameObject;
        textTop = text.transform.FindChild("top").gameObject;
        textBottom = text.transform.FindChild("bottom").gameObject;
        textContinue = text.transform.FindChild("continue").gameObject;

        buttons.SetActive(false);
        textTop.SetActive(false);
        textBottom.SetActive(false);
        gameObject.SetActive(false);
    }
}
