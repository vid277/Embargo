using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButtonDown("escapething") || Input.GetButtonDown("escape2")){
            //Debug.Log("Exit Game");
            Application.Quit();
        } else if (Input.GetButtonDown("returntomain")){
            SceneManager.LoadScene("Menu");
        }
    }
}
