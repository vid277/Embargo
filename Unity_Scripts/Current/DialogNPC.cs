using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogNPC : Interactable
{
    [SerializeField] private TextAssetValue dialogValue;
    [SerializeField] private TextAsset myDialog;
    [SerializeField] private SignalGame branchingDialogNotification;

    void Start()
    {
        
    }

    void Update()
    {
        if (playerInRange){
            if (Input.GetButtonDown("Check")){
                dialogValue.value = myDialog;
                branchingDialogNotification.callmethod();
            }
        }
    }
}
