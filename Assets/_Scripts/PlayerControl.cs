using UnityEngine;
using System.Collections;

public enum EntityState {NORMAL, ATTACKING};

public class PlayerControl : MonoBehaviour {

    public Sprite[] runRight;
	public Sprite[] jump;
	public Sprite[] idle;
    public Sprite[] crouch;

    SpriteRenderer sr;
    Rigidbody2D rigid;
    StateMachine animation_state_machine;
    public EntityState current_state = EntityState.NORMAL;
    private float iH;
    public float moveSpeed = 5f;

    static bool split = false; //false = together, true = split
    public GameObject top;// = Instantiate(Resources.Load("_prefabs/head")) as GameObject;
    public GameObject bottom;// = Instantiate(Resources.Load("_prefabs/bottom")) as GameObject;
    public GameObject wholebody;// = Instantiate(Resources.Load("_prefabs/full body")) as GameObject;

    // Use this for initialization
    void Start ()
    {
        rigid = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animation_state_machine = new StateMachine();
        animation_state_machine.ChangeState(new StateIdleWithSprite(this, sr, idle[0]));
    }
	
	// Update is called once per frame
	void Update ()
    {
        animation_state_machine.Update();
        //iV = Input.GetAxis("A");
        iH = Input.GetAxis("Left Joystick X") * 5f;

        if (Input.GetButtonDown("Right Bumper")) {
            //call split funcation
            split = !split;
            splitOrCombine(split);
        }

        if (Input.GetButtonDown("B")) {
            //Jump
            rigid.velocity = new Vector3(iH * moveSpeed, rigid.velocity.y + 5f, 0f);
            Debug.Log("Jumping");
        }

        if (Input.GetButtonDown("A")) {
            //Attack
            Debug.Log("Attacking");
        }
    }

    void splitOrCombine(bool breakup) {
        Debug.Log("Split Var: " + breakup);
        if (breakup) {
            //split
            top.SetActive(true);
            bottom.SetActive(true);
            wholebody.SetActive(false);
            Debug.Log("Split");
        }
        else {
            //recombine
            top.SetActive(false);
            bottom.SetActive(false);
            wholebody.SetActive(true);
            Debug.Log("Combine");
        }
        //DestroyObject(gameObject); //may need to hide
        //gameObject.GetComponent<Renderer>().enabled = false;

    }

    void FixedUpdate()
    {
        iH = Input.GetAxis("Left Joystick X");
        rigid.velocity = new Vector3(iH * moveSpeed, rigid.velocity.y, 0f);
    }
}
