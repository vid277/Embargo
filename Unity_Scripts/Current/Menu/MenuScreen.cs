
/*

@Author Vidyoot Senthilvenkatesh
@Version 2/8/2022

*/using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


    /**
     * Loads the leaderboard UIs based on what mode the player chooses
     **/
public class MenuScreen : MonoBehaviour
{
    public static int Numberoftries = 0;

    public void Singleplayer(){
        SceneManager.LoadScene("Singleplayer");
    }

    public void Multiplayer(){
        SceneManager.LoadScene("Multiplayer");
    }
    /**
     * Loads the scene after the player retrys and resets the player's scores. Also adds  to the number of tries
    **/
    public void Retry(){
        SceneManager.LoadScene("Singleplayer");
        PlayerPrefs.SetString("Score", "0");
        Enemy.score = 0;
        Numberoftries++;
    }

    /**
     * Loads the scene after the player returns to menu and resets the player's scores. Also adds to the number of tries
    **/

    public void ReturntoMenu(){
        SceneManager.LoadScene("MenuScreen");
        PlayerPrefs.SetString("Score", "0");
        Enemy.score = 0;
        Numberoftries++;
    }
    /**
     * Quits the game.
     **/
    public void quitgame(){
        Application.Quit();
    }
}
