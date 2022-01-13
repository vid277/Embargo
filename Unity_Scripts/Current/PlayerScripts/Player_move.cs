using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    void Start()
    {
        //currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
        transform.position = positiontostart.initialValue;
    }

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
    
    void MoveCharacter()
    {  
        change.Normalize();
        myRigidBody.MovePosition(
            transform.position + change * speed * Time.deltaTime
        );
    }

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
