/*

@Author Vidyoot Senthilvenkatesh
@Version 2/21/2022

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clues : MonoBehaviour
/*Activates and deactivates clues*/
{
    public GameObject contextClues;
    public bool contextActive = false;

    public void ChangeContext() {
        contextActive = !contextActive;
        if(contextActive){
            contextClues.SetActive(true);
        }
        else{
            contextClues.SetActive(false);
        }
    }
}
