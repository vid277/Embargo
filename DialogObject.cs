using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogObject : MonoBehaviour
{
    [SerializeField] private Text myText;
    public void Setup(string newDialog){
        myText.text = newDialog;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
