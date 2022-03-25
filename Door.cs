using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public GameObject showscore;
    public Text textbox;
    public string texttype;
    public float speed;

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
                else if (playerInventory.keycount == 0) {
                    showscore.SetActive(true);
                    StartCoroutine(someco());
                }
            }
        }
    }

    public void Open()
    {
        doorSprite.enabled = false;
        open = true;
        physicsCollider.enabled = false;
        mybody.SetActive(false);
    }

    public IEnumerator someco(){
        for(int i = 0; i < texttype.Length; i++){
            string currenttyping = texttype.Substring(0,i);
            textbox.text = currenttyping;
            yield return new WaitForSeconds(speed);
        }
        yield return new WaitForSeconds(3.5f);
        showscore.SetActive(false);
    }
}