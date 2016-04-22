using UnityEngine;
using System.Collections;

public class InteractableHideObject : MonoBehaviour {

    public new GameObject gameObject; //Object player can hide behind
    public SpriteRenderer floatingButton; //button that floats overhead
    public static bool characterHidden = false;
    static bool canHide = false;

    void Start() {

        floatingButton.enabled = false;
    }
    
    void Update() {
        if (canHide && (Input.GetButtonDown("X_1") || Input.GetButtonDown("X_2"))) {
            Debug.Log("Player has entered");

            Hide_UnHidePlayers();
        }
    }

    void FixedUpdate() {
        if (characterHidden) {
            gameObject.GetComponent<Rigidbody2D>().MoveRotation(Mathf.LerpAngle(-45f, 45f, Time.time));//must fix
        }
        else {
            gameObject.GetComponent<Rigidbody2D>().MoveRotation(0);// = (0, 0, objectRotation * -1);// = objectRotation * -1f;
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        floatingButton.enabled = true;
        canHide = true;
    }

    void OnTriggerExit2D(Collider2D col) {
        Debug.Log("Player has left");
        floatingButton.enabled = false;
        canHide = false;
    }

    public static bool MovementFreeze(bool canMove) {
        return canMove;
    }

    public void Hide_UnHidePlayers() {
        //public functions for player to hide behind objects
        Debug.Log("Player is trying to hide");
        characterHidden = !characterHidden;
        if (characterHidden) {//character is hiding behind object
            Debug.Log("Character Hidden");
            //move sprite layer
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 150;
            //disable character movement & splitting
            Player.hiding = MovementFreeze(true);
            //suspicion bar dimmed
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
