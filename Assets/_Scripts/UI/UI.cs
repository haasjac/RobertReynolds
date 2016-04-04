using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour {
    public static UI S;

    public Dialogue dialogue;
    //Whether or not the players are together
    public bool together, stopped;
    public Slider stealthBar;
    public float currentSuspicion, maxSuspicion;
    public GameObject clothes;
    public GameObject costume1_go;
    public GameObject costume2_go;
    public GameObject costume3_go;
    public AudioSource sound;

    Image costume1_img;
    Image costume2_img;
    Image costume3_img;

    [HideInInspector]
    public List<bool> has_costume;

    float ratio;
    void Awake()
    {
        S = this;
    }
    // Use this for initialization
    void Start ()
    {
        sound = Camera.main.GetComponent<AudioSource>();
        Image[] c = clothes.GetComponentsInChildren<Image>();
        costume1_img = c[0];
        costume2_img = c[1];
        costume3_img = c[2];
        costume1_img.sprite = costume1_go.GetComponent<SpriteRenderer>().sprite;
        costume2_img.sprite = costume2_go.GetComponent<SpriteRenderer>().sprite;
        costume3_img.sprite = costume3_go.GetComponent<SpriteRenderer>().sprite;
        costume1_img.color = Color.black;
        costume2_img.color = Color.black;
        costume3_img.color = Color.black;

        for(int i = 0; i < 5; i++) {
            has_costume.Add(false);
        }
        dialogue.init();
    }

    void Update() {
        ratio = currentSuspicion / maxSuspicion ;
        stealthBar.GetComponentInChildren<Image>().GetComponent<Image>().color = Color.Lerp(Color.red, Color.green, ratio);
        stealthBar.value = ratio;

        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

	public void ChangeSuspicion(float toAdd)
    {
        float test = currentSuspicion + toAdd;
        if (test > maxSuspicion)
            test = maxSuspicion;
        else if (test < 0) {
            test = 0;
        }
        currentSuspicion = test;
        if(toAdd < 0f)
        {
            StartCoroutine(Top.S.Flash());
            StartCoroutine(Bottom.S.Flash());
        }
    }
    public void Collect(GameObject go)
    {
        if(go == costume1_go)
        {
            costume1_img.color = Color.white;
            has_costume[1] = true;
        }
        else if(go == costume2_go)
        {
            costume2_img.color = Color.white;
            has_costume[2] = true;
        }
        else if(go == costume3_go)
        {
            costume3_img.color = Color.white;
            has_costume[3] = true;
        } else {
            print(go.name + " not set correctly in UI!");
        }
        if (has_costume[1] && has_costume[2] && has_costume[3]) {
            has_costume[0] = true;
        }
        PlaySound("Success");
    }
    public void PlaySound(string name)
    {
        sound.PlayOneShot(Resources.Load("Sounds/" + name) as AudioClip);
    }
}
