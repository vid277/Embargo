using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLog : log
{
    public GameObject projectile;
    public bool enableFiring;
    public float delay;
    private float delayInSeconds;

    void Update(){
        delayInSeconds -= Time.deltaTime;
        if (delayInSeconds <= 0){
            enableFiring = true;
            delayInSeconds = delay;
        } 
    }

    public override void targetDistance(){
        if(Vector3.Distance(target.position, transform.position) <= chaserad && Vector3.Distance(target.position, transform.position)> attackrad){
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                if (enableFiring){
                    Vector3 tempVector = target.transform.position - transform.position;
                    GameObject current = Instantiate(projectile, transform.position, Quaternion.identity);
                    current.GetComponent<Projectile>().shoot(tempVector);
                    enableFiring = false;
                    ChangingState(EnemyState.walk);
                    anim.SetBool("wakeup",true);
                }
            }
        } else if (Vector3.Distance(target.position, transform.position)> chaserad){
            anim.SetBool("wakeup", false);
        }
    }
}
