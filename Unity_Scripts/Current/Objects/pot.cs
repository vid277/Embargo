
/*

@Author Vidyoot Senthilvenkatesh
@Version 2/8/2022

*/using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pot : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
/*Allows the player to destroy the pots and activates the break animation*/
    public void destroy(){
        anim.SetBool("break", true);
        StartCoroutine(breakco());
    }

    IEnumerator breakco(){
        yield return new WaitForSeconds(.3f);
        this.gameObject.SetActive(false);
    }
}
