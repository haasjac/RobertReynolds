using UnityEngine;
using System.Collections;

public class Bottom : Player {
    public static Bottom S;
    AudioSource sound;
    public bool carried = false;
    public GameObject arrow, arrowHead;
    public SpriteRenderer arrow_sr;
    public float throwSpeed = 3f;
    public float maxArrow = 3f;
    public GameObject magnet;
    void Awake()
    {
        S = this;
    }
    // Use this for initialization
    new void Start ()
    {
        sound = GetComponent<AudioSource>();
        arrow_sr = arrow.GetComponent<SpriteRenderer>();
        base.Start();
    }
    new void Update()
    {
        if(!carried)
        {
            base.Update();
        }
        else
        {
            if (Top.S.carrying)
            {
                container.transform.position = new Vector2(Top.S.container.transform.position.x + (facingRight ? 1.3f : -1.3f), Top.S.container.transform.position.y + .7f);
                arrow.transform.localScale = new Vector3(2f + Mathf.Cos(2 * Mathf.PI * Time.time) * maxArrow, 1f, 1f);
                arrowHead.transform.position = new Vector3(facingRight ? arrow_sr.bounds.max.x : arrow_sr.bounds.min.x, arrowHead.transform.position.y, arrowHead.transform.position.z);
                if (Input.GetButtonDown("B_1"))
                {
                    magnet.SetActive(true);
                    rigid.velocity = new Vector2(arrow.transform.localScale.x * (facingRight ? 1f : -1f) * throwSpeed, 0f);
                    Bottom.S.arrow.SetActive(false);
                    Bottom.S.arrowHead.SetActive(false);
                    container.transform.parent = null;
                    anim.SetBool("walking", false);
                    Top.S.carrying = false;
                    rigid.gravityScale = 0f;
                    StartCoroutine(throwGravity());
                }
            }
        }
    }

    new void FixedUpdate()
    {
        if(!carried)
        {
            base.FixedUpdate();
            //Legs only attack together/fall down?
            if (grounded && walking && !sound.isPlaying)
            {
                sound.Play();
            }
            else if (!grounded || (!walking && sound.isPlaying))
            {
                sound.Stop();
            }
        }
    }
    IEnumerator throwGravity()
    {
        UI.S.PlaySound("Throw");
        yield return new WaitForSeconds(1.3f);
        rigid.gravityScale = 1f;
        magnet.SetActive(false);
        Top.S.magnet.SetActive(false);
    }
}
