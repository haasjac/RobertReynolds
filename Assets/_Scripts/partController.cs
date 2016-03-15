using UnityEngine;
using System.Collections;

public class partController : MonoBehaviour {

    public GameObject part;

    public int playerNum = 1;

    public float health;

    public Sprite[] runRight;
    public Sprite[] jump;
    public Sprite[] idle;
    public Sprite[] crouch;

    StateMachine animation_state_machine;
    public StateMachine control_state_machine;

    public float moveSpeed = 5f;    

    // Use this for initialization
    void Awake() {
        health = 1;

        animation_state_machine = new StateMachine();
        //animation_state_machine.ChangeState(new StateIdleWithSprite(this, sr, idle[0]));

        control_state_machine = new StateMachine();
    }

    void Update() {
        animation_state_machine.Update();
        control_state_machine.Update();
    }

    void OnMouseDown() {
        //health -= 0.1f;
    }
}
