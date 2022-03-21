using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingbox : MonoBehaviour
{
    public bool playerInRange;
    private PatrolLog logmove;
    public int currentGoal;

    /*private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy")){
            playerInRange = true;
            logmove.setcurrentpoint(currentGoal);
            Debug.Log("Change Success");
        }    
    }*/
}
