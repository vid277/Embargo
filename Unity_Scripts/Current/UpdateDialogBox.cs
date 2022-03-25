using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateDialogBox : Interactable
{
    public GameObject branchingCanvas;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerInRange){
            branchingCanvas.SetActive(false);
        }
    }
}
