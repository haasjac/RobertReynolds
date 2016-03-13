using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class globals {
    
    private static globals _s = null;

    //Global Variables

    private globals() {
        //initialize variables

        load();
    }

    public static globals S
    {
        get
        {
            if (_s == null)
                _s = new globals();
            return _s;
        }
    }

    public void save() {
        //save Variables to PlayerPrefs

        //Save
        PlayerPrefs.Save();
    }

    public void load() {
        //load PlayerPrefs to Variables
    }
}
