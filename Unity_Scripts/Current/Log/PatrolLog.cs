using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolLog : log
{
    public Transform[] path;
    public int currentPoint;
    public Transform currentGoal;
    public float roundingDistance;
    public BoxCollider2D box1;
    public BoxCollider2D box2;

    void Update()
    {
        
    }

    /*
        Detects if the player is close and starts the animation and moves the enemy towars the player
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
        } else if (Vector3.Distance(target.position, transform.position) > chaserad){
/*
Moves enemies toward the palyer without activation the animation
*/
            if (Vector3.Distance(transform.position, path[currentPoint].position) > roundingDistance){

                Vector3 temp = Vector3.MoveTowards(transform.position, path[currentPoint].position, Speed * Time.deltaTime);
                changingAnimations(temp - transform.position);
                body.MovePosition(temp);
            }
            else{
                ChangeGoal();
            }
        }
    }

/*Moves the enemy back and forth */
    public void ChangeGoal(){
        if (currentPoint == path.Length - 1){
            currentPoint = 0;
            currentGoal = path[0];
        }
        else{
            currentPoint++;
            currentGoal = path[1];
        }
    }

   
     public void setcurrentpoint(int point){
        /*if (currentPoint == path.Length - 1){
            currentPoint = 0;
            currentGoal = path[0];
        }
        else{
            currentPoint = 1;
            currentGoal = path[1];
        }*/
        currentPoint = point;
        currentGoal = path[point];
    }


}
