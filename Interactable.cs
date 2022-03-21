using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public SignalGame context;
    public bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player") && !other.isTrigger){
            context.callmethod();
            playerInRange = true;
        }    
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player") && !other.isTrigger){
            context.callmethod();
        }
    }
}
