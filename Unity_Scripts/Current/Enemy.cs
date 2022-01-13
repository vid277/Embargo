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

    
    private void Awake() {
        health = maxHealth.initialValue;
    }

    private void damages(float damage){
        health = health - damage;
        if(health <= 0){
            DeathEffect();
            this.gameObject.SetActive(false);
            score = score + enemypoints;
        }
    }

    private void DeathEffect(){
        if(deathEffect != null){
            GameObject death = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(death, 1f);
        }
    }

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
