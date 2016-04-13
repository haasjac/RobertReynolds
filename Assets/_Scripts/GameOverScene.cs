using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour {
    AudioSource sound;
    public Text gameOverText, prompt1, prompt2;
    public Image button1, button2;
    public GameObject topClapboard;
    bool start = false;
    string display = "G A M E O V E R";
    Animation anim;
	// Use this for initialization
	void Start ()
    {
        sound = GetComponent<AudioSource>();
        anim = topClapboard.GetComponent<Animation>();
        StartCoroutine(GameOverSequence());
	}
    void Update()
    {
        if(Input.GetButtonDown("A_1") || Input.GetButtonDown("A_2"))
        {
            SceneManager.LoadScene(PlayerPrefs.GetString("PrevScene"));
        }
        if(Input.GetButtonDown("B_1") || Input.GetButtonDown("B_2"))
        {
            SceneManager.LoadScene("Title");
        }
    }
    void FixedUpdate()
    {
        if(start)
        {
            prompt1.color = new Color(prompt1.color.r, prompt1.color.g, prompt1.color.b, Mathf.Sin(2 * Time.fixedTime));
            prompt2.color = prompt1.color;
            button1.color = prompt1.color;
            button2.color = prompt1.color;
        }
    }
	IEnumerator GameOverSequence()
    {
        sound.PlayOneShot(Resources.Load("Sounds/Cut") as AudioClip);
        yield return new WaitForSeconds(1.8f);
        anim.Play("Top Clapboard");
        sound.PlayOneShot(Resources.Load("Sounds/Clapboard") as AudioClip);
        sound.Play();
        foreach(char x in display)
        {
            if(x == ' ')
            {
                gameOverText.text += x;
            }
            else
            {
                gameOverText.text += x;
                yield return new WaitForSeconds(.6f);
            }
        }
        start = true;
    }
}
