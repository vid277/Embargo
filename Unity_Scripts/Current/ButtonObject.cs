using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonObject : MonoBehaviour
{
    [SerializeField] private Text myText;
    [SerializeField] private int choiceValue;
    public void Setup(string newDialog, int myChoice){
        myText.text = newDialog;
        choiceValue = myChoice;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
