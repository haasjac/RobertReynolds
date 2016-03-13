using UnityEngine;
using System.Collections;

public enum EntityState {NORMAL, ATTACKING};

public class PlayerControl : MonoBehaviour {

	public Sprite[] runLeft;
	public Sprite[] runRight;
	public Sprite[] jump;
	public Sprite[] idle;
    public Sprite[] crouch;

    SpriteRenderer sr;
    Rigidbody2D rigid;
    StateMachine animation_state_machine;
	StateMachine control_state_machine;
    public EntityState current_state = EntityState.NORMAL;
    private float iH;
    public float moveSpeed = 5f;
    // Use this for initialization
    void Start ()
    {
        rigid = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animation_state_machine = new StateMachine();
        animation_state_machine.ChangeState(new StateIdleWithSprite(this, sr, idle[0]));
        control_state_machine = new StateMachine();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            rigid.velocity = new Vector3(-1f, rigid.velocity.y, 0f);
        }
        else if(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            rigid.velocity = new Vector3(0f, rigid.velocity.y, 0f);
        }
        iH = Input.GetAxis("Horizontal");
        animation_state_machine.Update();
        control_state_machine.Update();
    }
    void FixedUpdate()
    {
        rigid.velocity = new Vector3(iH * moveSpeed, rigid.velocity.y, 0f);
    }
}
