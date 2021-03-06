﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public static UI S;

    public Dialogue dialogue;
    public bool mega= true;
    //Whether or not the players are together
    public bool together, stopped;
    public Slider stealthBar;
    public float currentSuspicion, maxSuspicion, desSuspicion;
    public GameObject clothes;
    public GameObject costume1_go;
    public GameObject costume2_go;
    public GameObject costume3_go;
    public AudioSource sound;
    public Image megaphone, action, startBack;
    Image costume1_img;
    Image costume2_img;
    Image costume3_img;
    bool startAction;
    
    [HideInInspector]
    public List<bool> has_costume;

    float ratio;
    void Awake()
    {
        S = this;
        Time.timeScale = 1;
    }
    // Use this for initialization
    void Start()
    {
        PlayerPrefs.SetString("PrevScene", SceneManager.GetActiveScene().name);
        megaphone.gameObject.SetActive(true);
        action.gameObject.SetActive(true);
        startBack.gameObject.SetActive(true);
        sound = Camera.main.GetComponent<AudioSource>();
        //stealthBarHiding = UI.S.GetComponent<RectTransform>().FindChild("Stealth Bar").gameObject;
        Image[] c = clothes.GetComponentsInChildren<Image>();
        costume1_img = c[0];
        costume2_img = c[1];
        costume3_img = c[2];
        if (costume1_go && costume2_go && costume3_go)
        {
            costume1_img.sprite = costume1_go.GetComponent<SpriteRenderer>().sprite;
            costume2_img.sprite = costume2_go.GetComponent<SpriteRenderer>().sprite;
            costume3_img.sprite = costume3_go.GetComponent<SpriteRenderer>().sprite;
        }
        costume1_img.color = Color.black;
        costume2_img.color = Color.black;
        costume3_img.color = Color.black;

        for (int i = 0; i < 5; i++)
        {
            has_costume.Add(false);
        }
        dialogue.init();
        if (mega)
        {
            StartCoroutine(StartLevel());
        } else {
            stopped = false;
        }
        desSuspicion = currentSuspicion;
    }

    void Update()
    {
        ratio = currentSuspicion / maxSuspicion;
        stealthBar.GetComponentInChildren<Image>().GetComponent<Image>().color = Color.Lerp(Color.red, Color.green, ratio);
        stealthBar.value = ratio;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("Title");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene("VentLevel");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene("WesternLevel");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SceneManager.LoadScene("SciFiLevel");
        }
    }
    void FixedUpdate()
    {
        currentSuspicion = Mathf.Lerp(currentSuspicion, desSuspicion, Time.fixedDeltaTime);
        if (startAction)
        {
            startBack.color = new Color(startBack.color.r, startBack.color.g, startBack.color.b, Mathf.Lerp(startBack.color.a, 0f, .05f));
            float newScale = Mathf.Lerp(action.transform.localScale.x, 10f, .05f);
            action.transform.localScale = new Vector3(newScale, newScale, 1f);
            action.transform.Rotate(0f, 0f, 7.5f);
        }
    }
    public void ChangeSuspicion(float toAdd)
    {
        if (!InteractableHideObject.characterHidden) {
            if (toAdd < 0f) {
                StartCoroutine(Top.S.Flash());
                StartCoroutine(Bottom.S.Flash());
            } else if (toAdd > 0f) {
                PlaySound("Charging");
            }
            float test = desSuspicion + toAdd;
            if (test > maxSuspicion)
                test = maxSuspicion;
            else if (test < 0) {
                test = 0;
            }
            desSuspicion = test;
            if (desSuspicion <= 0f) {
                Time.timeScale = 1;
                SceneManager.LoadScene("GameOver");
            }
        }
    }
    public void Collect(GameObject go)
    {
        if (go == costume1_go)
        {
            costume1_img.color = Color.white;
            has_costume[1] = true;
        }
        else if (go == costume2_go)
        {
            costume2_img.color = Color.white;
            has_costume[2] = true;
        }
        else if (go == costume3_go)
        {
            costume3_img.color = Color.white;
            has_costume[3] = true;
        }
        else
        {
            print(go.name + " not set correctly in UI!");
        }
        if (has_costume[1] && has_costume[2] && has_costume[3])
        {
            has_costume[0] = true;
        }
        PlaySound("Success");
    }

    IEnumerator StartLevel()
    {
        UI.S.stopped = true;
        startAction = true;
        yield return new WaitForSeconds(1f);
        startAction = false;
        PlaySound("Action");
        yield return new WaitForSeconds(2f);
        Destroy(action.gameObject);
        Destroy(megaphone.gameObject);
        Destroy(startBack.gameObject);
        //clothes.SetActive(true);
        stealthBar.gameObject.SetActive(true);
        UI.S.stopped = false;
    }
    public void PlaySound(string name)
    {
        sound.PlayOneShot(Resources.Load("Sounds/" + name) as AudioClip);
    }

    void GameOverScreen() {
        //Ending screen
        GameOverButton.currentLevel = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("GameOver");
        //Spawn Robot mentor?
    }

    public void loadScene(string s)
    {
        SceneManager.LoadScene(s);
    }

}

