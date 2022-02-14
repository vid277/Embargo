
/*

@Author Vidyoot Senthilvenkatesh
@Version 2/8/2022

*/using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/*Loads the leaderboard UIs*/
public class MenuScreen : MonoBehaviour
{
    public static int Numberoftries = 0;

    public void Singleplayer(){
        SceneManager.LoadScene("Singleplayer");
    }

    public void Multiplayer(){
        SceneManager.LoadScene("Multiplayer");
    }
/*Makes the retry, return, and quit buttons*/
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
