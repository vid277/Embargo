using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.IO.Pipes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Awaken : MonoBehaviour
{
    public Animator anim;

    void Awake(){
        UnityEngine.Debug.Log("Awake");
        Time.timeScale = 1;  
        anim.SetBool("moving", false);  
        anim.SetBool("attacking", false);  
        anim.SetBool("dying", false);  
        anim.SetBool("hurt", false);  
    }

}
