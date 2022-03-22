/*

@Author Vidyoot Senthilvenkatesh
@Version 2/21/2022

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : log
{
        /**
         * Moves enemies toward the player and lets the enemeies attack the player when within range
         * @param temp Changes the animation of the zombie from idle to walking.
         * @param state Changes the state of the zombie to wallking.
         **/
    public override void targetDistance(){
        if(Vector3.Distance(target.position, transform.position) <= chaserad && Vector3.Distance(target.position, transform.position)> attackrad){
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                anim.SetBool("moving", true);
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
                changingAnimations(temp - transform.position);
                body.MovePosition(temp);
                ChangingState(EnemyState.walk);
            }
        } else if (Vector3.Distance(target.position, transform.position) < attackrad){
                if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
                {
                    StartCoroutine(attackco());
                }   
        }
    }
    
    /**
     *Defines that attack function. Activates the attack animation for 0.6 secionds then deactivates it
     @return float This is the time that the attack animation if played for
    **/

    public IEnumerator attackco(){
        currentState = EnemyState.attack;
        anim.SetBool("attacking", true);
        yield return new WaitForSeconds(0.6f);
        currentState = EnemyState.walk;
        anim.SetBool("attacking", false);
    }
}
