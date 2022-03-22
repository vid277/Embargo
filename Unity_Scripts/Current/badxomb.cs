/*

@Author Vidyoot Senthilvenkatesh
@Version 2/21/2022

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Creates the zombie enemy
 **/
public class badxomb : log
{
    public override void targetDistance(){
        if(Vector3.Distance(target.position, transform.position) <= chaserad && Vector3.Distance(target.position, transform.position)> attackrad){
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            /**
            * Makes the zombie walk toward the player if in range and animates it.
            * @param temp Changes the animation of the zombie from idle to walking.
            * @param state Changes the state of the zombie to wallking.
            **/
            {
                anim.SetBool("attacking", false);
                anim.SetBool("moving", true);
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
                changingAnimations(temp - transform.position);
                body.MovePosition(temp);
                ChangingState(EnemyState.walk);
            }
            /**
             * Makes the zombie attack the player if in range
             * @param state Changes the state of the zombie to attacking.
             **/
        } else if (Vector3.Distance(target.position, transform.position) < attackrad){
            ChangingState(EnemyState.attack);
            anim.SetBool("moving", true);
            anim.SetBool("attacking", true);
        }
    }
}
