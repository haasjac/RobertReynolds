using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Title : MonoBehaviour {
    public Image[] img = new Image[3];
    public Sprite[] defaultSprite = new Sprite[3];
    public Sprite[] selected = new Sprite[3];
    public GameObject[] ps = new GameObject[3];
    public int selectionNum = 0;
    AudioSource sound;
	// Use this for initialization
	void Start ()
    {
        sound = Camera.main.GetComponent<AudioSource>();
        img[0] = transform.FindChild("Start").GetComponent<Image>();
        img[1] = transform.FindChild("Controls").GetComponent<Image>();
        img[2] = transform.FindChild("Level Select").GetComponent<Image>();
    }
    // Update is called once per frame
    void Update()
{
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            sound.PlayOneShot(Resources.Load("Sounds/Ratchet") as AudioClip);
            img[selectionNum].sprite = defaultSprite[selectionNum];
            ps[selectionNum].SetActive(false);
            --selectionNum;
            if (selectionNum == -1)
            {
                selectionNum = 2;
            }
            else
            {
                selectionNum %= 3;
            }
            img[selectionNum].sprite = selected[selectionNum];
            ps[selectionNum].SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            sound.PlayOneShot(Resources.Load("Sounds/Ratchet") as AudioClip);
            img[selectionNum].sprite = defaultSprite[selectionNum];
            ps[selectionNum].SetActive(false);
            ++selectionNum;
            selectionNum %= 3;
            img[selectionNum].sprite = selected[selectionNum];
            ps[selectionNum].SetActive(true);
        }
        
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl) || Input.GetKeyDown(KeyCode.Return))
        {
            switch(selectionNum)
            {
                case 0:
                    SceneManager.LoadScene("_Scene_3_29");
                    break;
                case 1:
                    SceneManager.LoadScene("Controls");
                    break;
                case 2:
                    SceneManager.LoadScene("Level_Select");
                    break;
            }
        }
    }
}
