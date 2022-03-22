/*

@Author Vidyoot Senthilvenkatesh
@Version 2/8/2022

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : Interactable
{
    public Item contents;
    public Inventory playerInventory;
    public bool isOpen;
    public SignalGame raiseItem;
    public GameObject dialogBox;
    public GameObject chest;
    public Text dialogText;
    private Animator anim;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange){
            if(!isOpen){
                openingthechest();
            }   
            else {
                Chestisalreadyopen();
            } 
        }
    }

    public void Chestisalreadyopen(){
        dialogBox.SetActive(false);
        //playerInventory.currentItem = null;
        raiseItem.callmethod();
        StartCoroutine(Knockbacking(chest, time));  
    }

    /**
     * Supposed to deactivate the chest after a certain amount of time
     * @param float The time that the chest is open
     **/
    private IEnumerator Knockbacking(GameObject chest, float time){
        if(chest != null){
            yield return new WaitForSeconds(time);
            chest.SetActive(false);
        }
    }
    /**
     *Allows the player to open the chest
    **/
    public void openingthechest(){
        dialogBox.SetActive(true);
        dialogText.text = contents.itemDescription;
        playerInventory.currentItem = contents;
        playerInventory.AddItem(contents);
        isOpen = true;
        raiseItem.callmethod();
        context.callmethod();
        anim.SetBool("opened", true);
    }
    /**
     * Detects if the player is in range of the chest
     * @param other This is the range box for if the player is in range of the box.
     **/
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player") && !other.isTrigger &&!isOpen){
            context.callmethod();
            playerInRange = true;
        }    
    }

    /**
     * Detects if the player is on the chest and stops the player from walking ontop of it
     * @param other The hitbox of the chest that the player can't walk on.
     **/

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player") && !other.isTrigger &&!isOpen){
            context.callmethod();
        }
    }
}
