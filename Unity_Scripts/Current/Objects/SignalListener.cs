using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
