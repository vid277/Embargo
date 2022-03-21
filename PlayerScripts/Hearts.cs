using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hearts : MonoBehaviour
{
    public Image[] hearts;
    public Image[] deadhearts;
    public Sprite heart1;
    public Sprite heartHalf;
    public Sprite deadHeart;
    public FloatValue heartcont;
    public FloatValue playerCurrentHealth;
    public Animator animator;
    public Rigidbody2D myRigidBody;


    void Awake(){   
        initialHeartsCounts();
    }
    
    public void initialHeartsCounts(){
        for (int i = 0; i < heartcont.runtimevalue; i++){
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = heart1;
            changehearts();
        }
    }

    public void changehearts(){
            float tempHealth = playerCurrentHealth.runtimevalue/2;

            for (int i = 0; i < heartcont.runtimevalue; i++){
                if (i <= tempHealth - 0.5){
                    hearts[i].sprite = heart1;
                } else if (i > tempHealth){
                    hearts[i].sprite = deadHeart;
                } else {
                    hearts[i].sprite = heartHalf;
                }
            }
            
            /**if(tempHealth == 0){
                for (int i = 0; i < heartcont.initialValue; i++){
                    hearts[i].gameObject.SetActive(true);
                    hearts[i].sprite = deadHeart;
                }
                this.gameObject.SetActive(false);
                SceneManager.LoadScene("Dead");
            }*/
        }
}
