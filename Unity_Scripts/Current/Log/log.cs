/*

@Author Vidyoot Senthilvenkatesh
@Version 2/8/2022

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class log : Enemy
{
    public Transform target;
    public float chaserad;
    public float attackrad;
    public Transform home;
    public Rigidbody2D body;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;
        body = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
        anim = GetComponent<Animator>();
        anim.SetBool("wakeup", true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        targetDistance();
    }
    /*
    Detects if the player is close to the enemy and turns enemys out of idle animation
    */
    public virtual void targetDistance(){
        if(Vector3.Distance(target.position, transform.position) <= chaserad && Vector3.Distance(target.position, transform.position)> attackrad){
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {

                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
                changingAnimations(temp - transform.position);
                body.MovePosition(temp);
                ChangingState(EnemyState.walk);
                anim.SetBool("wakeup",true);
            }
        } else if (Vector3.Distance(target.position, transform.position)> chaserad){
            anim.SetBool("wakeup", false);
        }
    }

    /*
    Starts the moving animation
    */
    private void setVec(Vector2 setVector){
        anim.SetFloat("moveX", setVector.x);
        anim.SetFloat("moveY", setVector.y);
    }

    /*
    Moves the animation 
    */
    public void changingAnimations(Vector2 direction){
        if (Mathf.Abs(direction.x)>Mathf.Abs(direction.y)){
            if(direction.x > 0){
                setVec(Vector2.right);
            } else if (direction.x < 0){
                setVec(Vector2.left);
            }
        } else if (Mathf.Abs(direction.x)< Mathf.Abs(direction.y)){
            if(direction.y > 0){
                setVec(Vector2.up);
            } else if (direction.y < 0){
                setVec(Vector2.down);
            }
        }
    }
    public void ChangingState(EnemyState newState){
        if(currentState != newState){
            currentState = newState;
        }
    }
}
