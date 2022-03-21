using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clues : MonoBehaviour
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
