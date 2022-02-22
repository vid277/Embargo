/*

@Author Vidyoot Senthilvenkatesh
@Version 2/21/2022

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState{
    idle,
    walk,
    attack,
    stagger 
}
public class Enemy : MonoBehaviour
{
    public EnemyState currentState;
    public int baseAttack;
    public FloatValue maxHealth;
    public float health;
    public float Speed;
    public string enemyName;
    public GameObject deathEffect;
    public int enemypoints;
    public static int score;

    /*Sets the default health*/
    private void Awake() {
        health = maxHealth.initialValue;
    }
/*Allows the zombie to take damage and kills and plays the death animation when the health is below 0*/
    private void damages(float damage){
        health = health - damage;
        if(health <= 0){
            DeathEffect();
            this.gameObject.SetActive(false);
            score = score + enemypoints;
        }
    }
/*Removes the enemy when it is killed*/
    private void DeathEffect(){
        if(deathEffect != null){
            GameObject death = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(death, 1f);
        }
    }
/*Knocks the enemy back when hit*/
    public void knock(Rigidbody2D myRigidBody, float knockingtime, float damage){
        StartCoroutine(Knockbacking(myRigidBody, knockingtime));
        damages(damage);
    }

    private IEnumerator Knockbacking(Rigidbody2D myRigidBody, float time){
        if(myRigidBody != null){
            yield return new WaitForSeconds (time);
            myRigidBody.velocity = Vector2.zero;
            currentState = EnemyState.idle;
            myRigidBody.velocity = Vector2.zero;
        }
    }
}
