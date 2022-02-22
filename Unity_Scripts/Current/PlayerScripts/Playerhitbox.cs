/*

@Author Vidyoot Senthilvenkatesh
@Version 2/21/2022

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerhitbox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
/*Defines the player hitbox*/
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("breakable")){
            other.GetComponent<pot>().destroy();
        }
    }
}
