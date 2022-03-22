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

    /**
     * Sets the default health
     **/
    private void Awake() {
        health = maxHealth.initialValue;
    }
    /**
     *Allows the zombie to take damage and die. Also plays the death animation when the health is below 0
     *@param float This is the damage that zombie takes.
    **/
    private void damages(float damage){
        health = health - damage;
        if(health <= 0){
            DeathEffect();
            this.gameObject.SetActive(false);
            score = score + enemypoints;
        }
    }
    /**
     * Removes the enemy when it is killed after 1 second
    **/
    private void DeathEffect(){
        if(deathEffect != null){
            GameObject death = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(death, 1f);
        }
    }
    /**
     * Knocks the enemy back when hit
     * @param float This is the knockback that the enemy takes
     * @param damage This is the damage taht the enemy takes.
     **/
    public void knock(Rigidbody2D myRigidBody, float knockingtime, float damage){
        StartCoroutine(Knockbacking(myRigidBody, knockingtime));
        damages(damage);
    }

    /**
     * This resets the knockback after a certain amount of time.
     * @param float This is the time that the enemy is knocked backed by.
     * @return time This is how the game waits before the knockback is reset.
    **/

    private IEnumerator Knockbacking(Rigidbody2D myRigidBody, float time){
        if(myRigidBody != null){
            yield return new WaitForSeconds (time);
            myRigidBody.velocity = Vector2.zero;
            currentState = EnemyState.idle;
            myRigidBody.velocity = Vector2.zero;
        }
    }
}
