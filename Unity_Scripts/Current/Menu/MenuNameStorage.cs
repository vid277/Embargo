/*

@Author Vidyoot Senthilvenkatesh
@Version 2/10/2022

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Stores usernames in a string 
 * @param string This stores the imputed the username into a string.
 **/
public class MenuNameStorage : MonoBehaviour
{  
    public static string username1;
    public static string username2;
    public static bool multiplayer = false;

    public void storenamep1 (string input){
        username1  = input;
        PlayerPrefs.SetString("UsernameP1", username1.ToString());
    }
    
    public void storenamep2 (string input){
        username2  = input;
        PlayerPrefs.SetString("UsernameP2", username2.ToString());
        multiplayer = true;
    }

}
