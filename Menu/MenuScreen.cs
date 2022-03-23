using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour
{
    public static int Numberoftries = 0;

    public void Singleplayer(){
        SceneManager.LoadScene("Singleplayer");
        Numberoftries++;
        PlayerPrefs.SetString("Tries", Numberoftries.ToString());
    }

    public void Multiplayer(){
        SceneManager.LoadScene("Multiplayer");
    }

    public void Retry(){
        SceneManager.LoadScene("Singleplayer");
        PlayerPrefs.SetString("Score", "0");
        Enemy.score = 0;
        Numberoftries++;
        PlayerPrefs.SetString("Tries", Numberoftries.ToString());
    }

    public void ReturntoMenu(){
        SceneManager.LoadScene("MenuScreen");
        PlayerPrefs.SetString("Score", "0");
        Enemy.score = 0;
        //Numberoftries++;
        //PlayerPrefs.SetInteger("Tries", Numberoftries);
    }

    public void quitgame(){
        Application.Quit();
    }

    public void SwitchSceneCheat1(){
        SceneManager.LoadScene("Level1");
    }

    public void SwitchSceneCheat2(){
        SceneManager.LoadScene("Level2");
    }
}
