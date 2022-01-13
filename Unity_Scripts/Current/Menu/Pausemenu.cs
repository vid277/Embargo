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

    public void LoadMenu(){
        SceneManager.LoadScene("MenuScreen");
    }

    public void Exit(){
        Application.Quit();
    }

}
