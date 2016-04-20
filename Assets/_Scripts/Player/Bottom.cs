using UnityEngine;
using System.Collections;

public class Bottom : Player {
    public static Bottom S;
    AudioSource sound;
    public bool carried = false;
    public GameObject arrow, arrowHead;
    public SpriteRenderer arrow_sr;
    public float maxArrow = 3f;
    void Awake()
    {
        S = this;
    }
    // Use this for initialization
    new void Start ()
    {
        sound = GetComponent<AudioSource>();
        arrow_sr = arrow.GetComponent<SpriteRenderer>();
        base.Start();
    }
    new void Update()
    {
        if(!carried)
        {
            base.Update();
        }
        else
        {
            arrow.transform.localScale = new Vector3(2f + Mathf.Cos(2 * Mathf.PI * Time.time) * maxArrow, arrow.transform.localScale.y, arrow.transform.localScale.z);
            if (Input.GetButtonDown("B_1"))
            {
                container.transform.parent = null;
                carried = false;
                Top.S.carrying = false;
            }
        }
    }

    new void FixedUpdate()
    {
        if(!carried)
        {
            base.FixedUpdate();
            //Legs only attack together/fall down?
            if (grounded && walking && !sound.isPlaying)
            {
                sound.Play();
            }
            else if (!grounded || (!walking && sound.isPlaying))
            {
                sound.Stop();
            }
        }
    }
}
