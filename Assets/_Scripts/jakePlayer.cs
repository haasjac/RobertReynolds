using UnityEngine;
using System.Collections;

public class jakePlayer : MonoBehaviour {

    public float health;

    public Sprite[] runRight;
    public Sprite[] jump;
    public Sprite[] idle;
    public Sprite[] crouch;

    SpriteRenderer sr;
    Rigidbody2D rigid;
    StateMachine animation_state_machine;
    public StateMachine control_state_machine;
    public EntityState current_state = EntityState.NORMAL;
    private float iH;
    public float moveSpeed = 5f;

    static bool split = false; //false = together, true = split
    public GameObject top;// = Instantiate(Resources.Load("_prefabs/head")) as GameObject;
    public GameObject bottom;// = Instantiate(Resources.Load("_prefabs/bottom")) as GameObject;
    public GameObject wholebody;// = Instantiate(Resources.Load("_prefabs/full body")) as GameObject;

    // Use this for initialization
    void Start () {
        health = 1;
        rigid = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animation_state_machine = new StateMachine();
        //animation_state_machine.ChangeState(new StateIdleWithSprite(this, sr, idle[0]));
    }

    void Update() {
        animation_state_machine.Update();
        control_state_machine.Update();
    }
	
	void OnMouseDown() {
        health -= 0.1f;
    }
}
