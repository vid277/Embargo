using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class key : MonoBehaviour
{
    public Item contents;
    public Inventory playerInventory;
    public GameObject chest;
    private Animator anim;
    public float time;
    public bool isOkay = false;

    public void openingthechest(){
        playerInventory.currentItem = contents;
        playerInventory.AddItem(contents);
        isOkay = true;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player") && !other.isTrigger){
            openingthechest();
            chest.SetActive(false);
        }
    }

}
