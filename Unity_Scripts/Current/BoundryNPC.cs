using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundryNPC : Sign
{
    private Vector3 directions;
    private Transform transformNPC;
    public float speed;
    private Rigidbody2D myRigidBody;
    private Animator anim;
    public Collider2D bounds;
    public float minMoveTime;
    public float maxMoveTime;
    public float minWaitTime;
    public float maxWaitTime;
    private float moveTimeSeconds;
    private float waitTimeSeconds;
    private bool checkMoving;
    void Awake()
    {
        transformNPC = GetComponent<Transform>();
        myRigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        waitTimeSeconds = Random.Range(minWaitTime, maxWaitTime);
        moveTimeSeconds = Random.Range(minMoveTime, maxMoveTime);
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

    void OnCollisionEnter2D(Collision2D other){
        Vector3 position = directions;
        changeDirection();
        int tries = 0;
        while (directions == position && tries < 50){
            changeDirection();
            tries++;
        }
    }
    public override void Update()
    {
        base.Update();
        if (checkMoving){
            moveTimeSeconds -= Time.deltaTime;
            if (moveTimeSeconds <= 0){
                moveTimeSeconds = Random.Range(minMoveTime, maxMoveTime);
                checkMoving = false;
            }
            if (!playerInRange){
                moveNPC();
            }
        }
        else {
            waitTimeSeconds -= Time.deltaTime;
            if (waitTimeSeconds <= 0){
                differentDirection();
                checkMoving = true;
                waitTimeSeconds = Random.Range(minWaitTime, maxWaitTime);
            }
        }
    }
    public void differentDirection(){
        Vector3 position = directions;
        changeDirection();
        int tries = 0;
        while (directions == position && tries < 50){
            changeDirection();
            tries++;
        }
    }
}
