using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : Interactable
{
    public GameObject dialogueBox;
    public Text dialogueText;
    public Text decriptionText;
    public string dialog;
    public string decriptionTextbox;

    // Start is called before the first frame update
    void Start()
    {
        if (dialogueBox.activeInHierarchy)
        {
            dialogueBox.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange){
            if (dialogueBox.activeInHierarchy)
            {
                dialogueBox.SetActive(false);
            } else {
                dialogueBox.SetActive(true);
                dialogueText.text = dialog;
                decriptionText.text = decriptionTextbox;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player") && !other.isTrigger){
            context.callmethod();
            playerInRange = false;
            dialogueBox.SetActive(false);
        }
    }
}
