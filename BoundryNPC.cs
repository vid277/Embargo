using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundryNPC : Interactable
{
    private Vector3 directions;
    private Transform transformNPC;
    public float speed;
    private Rigidbody2D myRigidBody;
    private Animator anim;

    public Collider2D bounds;
    void Awake()
    {
        transformNPC = GetComponent<Transform>();
        myRigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        changeDirection();
    }

    void moveNPC(){
        Vector3 position = transformNPC.position + directions * speed * Time.deltaTime;
        if(bounds.bounds.Contains(position)){
            myRigidBody.MovePosition(position);
        }
        else {
            changeDirection();
        }
    }
    void changeDirection(){
        int direction = Random.Range(0, 4);
        switch (direction){
            case 0:
            directions = Vector3.right;
                break;
            case 1:
                directions = Vector3.up;
                break;
            case 2:
                directions = Vector3.down;
                break;
            case 4:
                directions = Vector3.left;
                break;
            default:
                break;
        }
        UpdateAnim();
    }

    void UpdateAnim(){
        anim.SetFloat("MoveX", directions.x);
        anim.SetFloat("MoveY", directions.y);
    }

    void OnCollisionEnter2D(Component other){
        Vector3 position = directions;
        changeDirection();
        int tries = 0;
        while (directions == position && loops < 100){
            changeDirection();
            loops++;
        }
    }
    void Update()
    {
        moveNPC();
    }
}
