using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupheart : Powerup
{
    public FloatValue playerHealth;
    public float increaseValue;
    public FloatValue heartContainer;

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player") && !other.isTrigger){
            playerHealth.runtimevalue += increaseValue;
            if (playerHealth.runtimevalue > heartContainer.runtimevalue * 2f){
                playerHealth.runtimevalue = heartContainer.runtimevalue*2f;
            }
            powerUpTime.callmethod();
            Destroy(this.gameObject);
        }
    }
}
