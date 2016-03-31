using UnityEngine;
using System.Collections;

public class Bottom : Player {
    public static Bottom S;
    void Awake()
    {
        S = this;
    }
    // Use this for initialization
    new void Start ()
    {
        base.Start();
        grounded = true;
    }
    new void Update()
    {
        base.Update();
    }

    new void FixedUpdate()
    {
        base.FixedUpdate();
        //Legs only attack together/fall down?
        if (UI.S.together)
        {
        }
        else
        {
            
        }
    }
}
