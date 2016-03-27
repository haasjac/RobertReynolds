using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class healthController : MonoBehaviour {

    public GameObject FullHealth;
    public Slider slider;

    public Image star1;
    public Image star2;
    public Image star3;

    float stealth;

    //public StateMachine sm;
    
	// Use this for initialization
	void Awake () {
        //sm = new StateMachine();
        
    }
	
	// Update is called once per frame
	void Update () {
        //sm.Update();
        stealth = playerController.S.stealth / playerController.S.max_stealth; ;
        FullHealth.GetComponent<Image>().color = Color.Lerp(Color.red, Color.green, stealth);
        slider.value = stealth;
        star1.color = (playerController.S.stars[1] ? Color.white : Color.black);
        star2.color = (playerController.S.stars[2] ? Color.white : Color.black);
        star3.color = (playerController.S.stars[3] ? Color.white : Color.black);
    }
}
