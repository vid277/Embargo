/*

@Author Vidyoot Senthilvenkatesh
@Version 2/21/2022

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hearts : MonoBehaviour
{
    public Image[] hearts;
    public Image[] deadhearts;
    public Sprite heart1;
    public Sprite heartHalf;
    public Sprite deadHeart;
    public FloatValue heartcont;
    public FloatValue playerCurrentHealth;

    void Awake(){   
        initialHeartsCounts();
    }
    /*Sets the initial heart value*/
    public void initialHeartsCounts(){
        for (int i = 0; i < heartcont.runtimevalue; i++){
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = heart1;
            changehearts();
        }
    }
/*Allows the player to lose hearts and kills the player when 0 hearts are left*/
    public void changehearts(){
            float tempHealth = playerCurrentHealth.runtimevalue/2;

            for (int i = 0; i < heartcont.runtimevalue; i++){
                if (i <= tempHealth - 1){
                    hearts[i].sprite = heart1;
                } else if (i > tempHealth){
                    hearts[i].sprite = deadHeart;
                } else {
                    hearts[i].sprite = heartHalf;
                }
            }
            
            if(tempHealth == 0){
                for (int i = 0; i < heartcont.initialValue; i++){
                    hearts[i].gameObject.SetActive(true);
                    hearts[i].sprite = deadHeart;
                }
                SceneManager.LoadScene("Dead");
            }
        }
    }
