using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour
{
    public static int Numberoftries = 0;

    public void Singleplayer(){
        SceneManager.LoadScene("Singleplayer");
    }

    public void Multiplayer(){
        SceneManager.LoadScene("Multiplayer");
    }

    public void Retry(){
        SceneManager.LoadScene("Singleplayer");
        PlayerPrefs.SetString("Score", "0");
        Enemy.score = 0;
        Numberoftries++;
    }

    public void ReturntoMenu(){
        SceneManager.LoadScene("MenuScreen");
        PlayerPrefs.SetString("Score", "0");
        Enemy.score = 0;
        Numberoftries++;
    }

    public void quitgame(){
        Application.Quit();
    }
}
