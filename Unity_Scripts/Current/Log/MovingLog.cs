/*

@Author Vidyoot Senthilvenkatesh
@Version 2/8/2022

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLog : log
{
    void Update()
    {
        
    }

  /*
  Moves enemys towards the player if they are withing radius
  */
    public override void targetDistance(){
        if(Vector3.Distance(target.position, transform.position) <= chaserad && Vector3.Distance(target.position, transform.position)> attackrad){
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {

                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
                changingAnimations(temp - transform.position);
                body.MovePosition(temp);
                //ChangingState(EnemyState.walk);
                anim.SetBool("wakeup",true);
            }
        } else if (Vector3.Distance(target.position, transform.position)> chaserad){
            
        }
    }
}
