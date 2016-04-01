using UnityEngine;
using System.Collections;

public class Cutscene : MonoBehaviour {
    //no need to mess with
    public virtual void Start() {
        Execute();
    }
    public virtual void Execute() {
        Exit();
    }
    public virtual void Exit() { }
}

//This is what every cutscene class should look like
/*Then in other files: 
    public Cutscene currentScene;
    currentCutscene = new NAMEOFYOUCUTSCENE();
    currentCutscene.Start()
*/
/*public class Cutscene_Template : MonoBehaviour {
    public override void Start() {
        //disable player movement and attack controls?
        //grab player reference and move to certain point
        base.Execute();
    }

    public override void Execute() {
        //bring up a dialog window where the player talks
        base.Exit();
    }

    public override void Exit() {
        //re-enable controls, other clean-up.
    }

}*/

/* Add any cutscenes below here */

public class IntroCutScene : Cutscene {
    public override void Start() {
        //disable player movement and attack controls?
        //grab player reference and move to certain point
        base.Execute();
    }

    public override void Execute() {
        //bring up a dialog window where the player talks
        base.Exit();
    }

    public override void Exit() {
        //re-enable controls, other clean-up.
    }
}
