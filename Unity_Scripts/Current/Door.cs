//This feature is still in development
/*

@Author Vidyoot Senthilvenkatesh
@Version 2/21/2022

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
    key,
    enemy,
    button
}

public class Door : Interactable
{
    [Header("Door variables")]
    public DoorType thisDoorType;
    public bool open = false;
    public Inventory playerInventory;
    public SpriteRenderer doorSprite;
    public BoxCollider2D physicsCollider;
    public GameObject mybody;
    public GameObject arrow;

    /*Allows the player to go through the door if the player has a key*/

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(playerInRange && thisDoorType == DoorType.key)
            {
                if(playerInventory.keycount > 0)
                {
                    playerInventory.keycount--;
                    Open();
                }
            }
        }
    }

    /*Sets the open door properties*/

    public void Open()
    {
        doorSprite.enabled = false;
        open = true;
        physicsCollider.enabled = false;
        mybody.SetActive(false);
        arrow.SetActive(true);
    }

    public void Close()
    {

    }
}

