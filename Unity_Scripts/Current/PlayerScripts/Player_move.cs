/*

@Author Vidyoot Senthilvenkatesh
@Version 2/21/2022

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This is the enum
public enum PlayerState{
    walk,
    attack,
    interact,
    stagger,
    idle
}

public class Player_move : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myRigidBody;
    private Vector3 change;
    private Animator animator;
    public static bool playeralive = true;
    public PlayerState currentState;
    public FloatValue currentHealth;
    public SignalGame playerHealthSignal;
    public Vectors positiontostart;
    public Inventory playerInventory;
    public SpriteRenderer itemspriterecieved;

/**
 * Starts the animation for the player walking 
 **/
    void Start()
    {
        //currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
        transform.position = positiontostart.initialValue;
    }
/**
*Moves the player on a 2D plane and changes the state of the player. Also detects when the player is attacking.
**/
    void Update()
    {
        if(currentState == PlayerState.interact)
        {
            return;
        }
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("attackit") && currentState != PlayerState.attack){
            StartCoroutine(Attackco());
        }
        else if (currentState == PlayerState.walk || currentState == PlayerState.idle){
           updateAnimAndMove(); 
        }
    }
    /**
     *Allows the player to attack and animates it. Also adds a delay so the player cannot move while attacking
     *@return float This returns the amount of time the player cannot move after attacking.
     **/
    private IEnumerator Attackco(){
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.2f);
        if(currentState!= PlayerState.interact){
            currentState = PlayerState.walk;
        }
    }
/**
 * Animates the player when items are picked up and allows the player to pick up items*
 **/
    public void RaiseItem(){
        if (playerInventory.currentItem != null){
            if (currentState != PlayerState.interact){
                animator.SetBool("recieveItem", true);
                currentState = PlayerState.interact;
                itemspriterecieved.sprite = playerInventory.currentItem.itemSprite;
            }  
            else{
                animator.SetBool("recieveItem", false);
                currentState = PlayerState.idle;
                itemspriterecieved.sprite = null;
                playerInventory.currentItem = null;
            }
        }
    }
/**
 * Animates the player while moving and sets the state of the player to walking. Sets a different animation based on the direction the player is moving.
 **/
    void updateAnimAndMove(){
        if (change != Vector3.zero){
            MoveCharacter();
            animator.SetBool("moving", true);
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            currentState = PlayerState.walk;
        }
        else{
            animator.SetBool("moving", false);
        }
    }
    /**
     * Changes the speed when the player moves
     ***/
    void MoveCharacter()
    {  
        change.Normalize();
        myRigidBody.MovePosition(
            transform.position + change * speed * Time.deltaTime
        );
    }
/**
 * Allows the player to take damage when hit and get knocked back. Kills the player if their health went to zero.
 * @param KnockTime The time that the player is being knocked back.
 * @param damage The damage that the player is taking.
 **/
    public void knock(float KnockTime, float damage){
        currentHealth.runtimevalue -= damage;   
        playerHealthSignal.callmethod();
        if(currentHealth.runtimevalue > 0){
            StartCoroutine(Knockbacking(KnockTime));
        }
        else {
            playeralive = false;
            this.gameObject.SetActive(false);
            SceneManager.LoadScene("Dead");
        }
        
    }
/**
 * This defines the knockback mechanic on the player and moves the player based on how much knockback they took
 * @param KnockTime The time that the player is being knocked back for from the enemy
 * @return KnockTime The time that the player will take knockback
 **/
    private IEnumerator Knockbacking(float KnockTime){
        if(myRigidBody != null){
            //currentState = PlayerState.stagger;
            yield return new WaitForSeconds (KnockTime);
            myRigidBody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            myRigidBody.velocity = Vector2.zero; 
        }
}
}
