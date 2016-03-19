using UnityEngine;
using System.Collections;

public enum EntityState { NORMAL, ATTACKING };

public class partController : MonoBehaviour {

    public GameObject part;

    public int playerNum = 1;

    public float max_health = 1;
    public float health;

    public Sprite[] runRight;
    public Sprite[] jump;
    public Sprite[] idle;
    public Sprite[] crouch;

    StateMachine animation_state_machine;
    public StateMachine control_state_machine;

    public EntityState current_state;

    public float moveSpeed = 5f;
    public bool grounded;

    // Use this for initialization
    void Awake() {
        health = max_health;

        animation_state_machine = new StateMachine();
        animation_state_machine.ChangeState(new StateIdleWithSprite(this, part.GetComponent<SpriteRenderer>(), idle[0]));

        control_state_machine = new StateMachine();

        current_state = EntityState.NORMAL;
        grounded = false;
    }

    void Update() {
        animation_state_machine.Update();
        control_state_machine.Update();
        if (health <= 0) {
            GetComponentInParent<playerController>().dead();
        }
    }
    
}
