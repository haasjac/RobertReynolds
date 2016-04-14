using UnityEngine;
using System.Collections;

public class InteractableHideObject : MonoBehaviour {

    public GameObject gameObject; //Object player can hide behind
    public SpriteRenderer floatingButton; //button that floats overhead
    public static bool characterHidden = false;

    static float objectRotation = 45f;

   // GameObject stealthBarHiding;

    void Start() {
        //floatingButton = gameObject.GetComponentInChildren<SpriteRenderer>();
        //startpos = gameObject.GetComponent<Transform>().
    }
    
    void FixedUpdate() {
        if (characterHidden) {
            objectRotation *= -1;
            gameObject.GetComponent<Rigidbody2D>().MoveRotation(objectRotation);//must fix
        }
        else {
            gameObject.GetComponent<Rigidbody2D>().MoveRotation(0);// = (0, 0, objectRotation * -1);// = objectRotation * -1f;
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        Debug.Log("Player has entered");
        //if(col.gameObject.tag == "Whole") {
            floatingButton.enabled = true;
        //}
    }

    void OnTriggerStay2D(Collider2D col) {
        //players are whole 
        //players are separate
        if((col.gameObject.layer == 8) && (Input.GetButtonDown("X_1") || Input.GetButtonDown("X_2"))) {
            Hide_UnHidePlayers();
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        Debug.Log("Player has left");
        floatingButton.enabled = false;
    }

    public static bool MovementFreeze(bool canMove) {
        return canMove;
    }

    public void Hide_UnHidePlayers() {
        //public functions for player to hide behind objects
        characterHidden = !characterHidden;
        if (characterHidden) {//character is hiding behind object
            Debug.Log("Character Hidden");
            //move sprite layer
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 150;
            //disable character movement & splitting
            Player.hiding = MovementFreeze(true);
            //suspicion bar dimmed
            //UI.S.GetComponentInChildren<CanvasRenderer>().SetAlpha(0f);
            //UI.S.stealthBarHiding.G = false;
            UI.S.enabled = false;
        }
        else {
            Debug.Log("Character Not Hidden");
            //unhide character
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = -11;
            //re-enable movement & spliiting
            Player.hiding = MovementFreeze(false);
            //suspicion bar brighten
            UI.S.enabled = true;
        }
    }
}
