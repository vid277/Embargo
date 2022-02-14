/*

@Author Vidyoot Senthilvenkatesh
@Version 2/8/2022

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//Creates a scriptable signal listener
public class SignalListener : MonoBehaviour
{
    public SignalGame signal;
    public UnityEvent signalEvent;

    public void OnSignalCall(){ 
        signalEvent.Invoke();
    }

    private void OnEnable() {
        signal.RegisterListener(this);
    }

    private void OnDisable() {
        signal.DeRegisterListener(this);
    }
}
