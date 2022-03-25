using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Move")]
    public float speed;
    public Vector2 direction;
    [Header("Duration Period")]
    public float LifeTime;
    private float LifeTimeSeconds;
    public Rigidbody2D myRigidBody;
    public Animator anim;

    void Start()
    {
        LifeTimeSeconds = LifeTime;
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        LifeTimeSeconds -= Time.deltaTime;
        if (LifeTimeSeconds <= 0){
            anim.SetBool("destroy", true);
            Destroy(this.gameObject);
        }
    }

    public void shoot(Vector2 playerLocation){
        myRigidBody.velocity = playerLocation * speed;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        anim.SetBool("destroy", true);
        Destroy(this.gameObject);
    }
}
