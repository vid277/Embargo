/*

@Author Vidyoot Senthilvenkatesh
@Version 2/8/2022

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pausemenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pausing;

    public GameObject blur;
    /**
     * Pauses the game when the player presses escape. 
     **/
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if(GameIsPaused){
                resume();
            }
            else{
                pause();
            }
        }
    }

    public void resume(){
        pausing.SetActive(false);
        blur.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    
    public void pause(){
        pausing.SetActive(true);
        blur.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    /**
     * Returns the player to the menu when they press the menu button.
     **/
    public void LoadMenu(){
        SceneManager.LoadScene("MenuScreen");
    }
    /**
     * Exits the game when the player presses the button.
     **/
    public void Exit(){
        Application.Quit();
    }

}
