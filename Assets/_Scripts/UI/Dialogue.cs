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

    public GameObject buttons;
    public Sprite player_face;
    public Sprite question_mark;

    public void init() {
        S = this;
        buttons.SetActive(false);
        gameObject.SetActive(false);
        text = GetComponentInChildren<Text>();
        background = GetComponentsInChildren<Image>()[0];
        face = GetComponentsInChildren<Image>()[1];
    }
}
