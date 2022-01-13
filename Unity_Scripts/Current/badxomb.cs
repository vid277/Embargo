using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class badxomb : log
{
    public override void targetDistance(){
        if(Vector3.Distance(target.position, transform.position) <= chaserad && Vector3.Distance(target.position, transform.position)> attackrad){
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                anim.SetBool("attacking", false);
                anim.SetBool("moving", true);
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
                changingAnimations(temp - transform.position);
                body.MovePosition(temp);
                ChangingState(EnemyState.walk);
            }
        } else if (Vector3.Distance(target.position, transform.position) < attackrad){
            ChangingState(EnemyState.attack);
            anim.SetBool("moving", true);
            anim.SetBool("attacking", true);
        }
    }
}
