using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI : MonoBehaviour {
    public static UI S;
    //Whether or not the players are together
    public bool together;
    public GameObject Suspicion;
    int star = 0;
    public Image star1;
    public Image star2;
    public Image star3;
    public AudioSource sound;
    void Awake()
    {
        S = this;
    }
    // Use this for initialization
    void Start ()
    {
        sound = Camera.main.GetComponent<AudioSource>();
    }
	void ChangeSuspicion(float toAdd)
    {
        Vector2 fullSize = FullHealth.GetComponent<RectTransform>().sizeDelta;
        fullSize.x = (fullHealth / fullMaxHealth) * 150f;
        FullHealth.GetComponent<RectTransform>().sizeDelta = fullSize;
    }
    public void Collect()
    {
        if(star == 0)
        {
            star1.color = Color.white;
        }
        else if(star == 1)
        {
            star2.color = Color.white;
        }
        else
        {
            star3.color = Color.white;
        }
        PlaySound("Success");
    }
    public void PlaySound(string name)
    {
        sound.PlayOneShot(Resources.Load("Sounds/" + name) as AudioClip);
    }
}
