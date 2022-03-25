/**
    This class procces when the user is near a context clue such as a sign and renders a sprite above the character

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


    /**
    * This is used to activate and deactivate clues based upon whether the player is within range of the trigger.
    */
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
