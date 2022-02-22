/*

@Author Vidyoot Senthilvenkatesh
@Version 2/21/2022

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : log
{
        /*Moves enemies toward the player and lets the enemeies attack the player when within range*/
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

    public IEnumerator attackco(){
        currentState = EnemyState.attack;
        anim.SetBool("attacking", true);
        yield return new WaitForSeconds(0.6f);
        currentState = EnemyState.walk;
        anim.SetBool("attacking", false);
    }
}
