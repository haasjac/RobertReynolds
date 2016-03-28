using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI : MonoBehaviour {
    public static UI S;
    //Whether or not the players are together
    public bool together, stopped;
    public Slider stealthBar;
    public GameObject Suspicion;
    public float currentSuspicion, maxSuspicion;
    int star = 0;
    public Image star1;
    public Image star2;
    public Image star3;
    public AudioSource sound;

    float stealth;
    void Awake()
    {
        S = this;
    }
    // Use this for initialization
    void Start ()
    {
        sound = Camera.main.GetComponent<AudioSource>();
    }

    void Update() {
        stealth = playerController.S.stealth / playerController.S.max_stealth; ;
        stealthBar.GetComponentInChildren<Image>().GetComponent<Image>().color = Color.Lerp(Color.red, Color.green, stealth);
        stealthBar.value = stealth;
    }

	public void ChangeSuspicion(float toAdd)
    {
        Vector2 fullSize = Suspicion.GetComponent<RectTransform>().sizeDelta;
        fullSize.x = (currentSuspicion / maxSuspicion) * 150f;
        Suspicion.GetComponent<RectTransform>().sizeDelta = fullSize;
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
