using UnityEngine;
using System.Collections;

public class Bottom : Player {
    public static Bottom S;
    AudioSource sound;
    void Awake()
    {
        S = this;
    }
    // Use this for initialization
    new void Start ()
    {
        sound = GetComponent<AudioSource>();
        base.Start();
    }
    new void Update()
    {
        base.Update();
    }

    new void FixedUpdate()
    {
        base.FixedUpdate();
        //Legs only attack together/fall down?
        if (walking && !sound.isPlaying)
        {
            sound.Play();
        }
        else if(!walking && sound.isPlaying)
        {
            sound.Stop();
        }
    }
}
