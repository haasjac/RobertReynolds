using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverButton : MonoBehaviour {
    public GameObject ClapBoard;
    public static string currentLevel;

    public void OnPointerEnter() {
        ClapBoard.transform.Rotate(new Vector3(0,0,-24.94f));
    }

    public void OnPointerClick() {
        UI.S.PlaySound("Action");
        //SceneManager.LoadScene(currentLevel);
    }
}
