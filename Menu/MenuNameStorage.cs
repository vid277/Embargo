using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
