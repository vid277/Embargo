/*

@Author Vidyoot Senthilvenkatesh
@Version 2/21/2022

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SignalGame : ScriptableObject
{
    public List<SignalListener> Listeners = new List<SignalListener>();
/*Creates a signal listener*/
    public void callmethod(){
        for(int i = Listeners.Count-1; i>=0; i--){
            Listeners[i].OnSignalCall();
        }
    }

    public void RegisterListener(SignalListener listener){
        Listeners.Add(listener);
    }

    public void DeRegisterListener(SignalListener listener){
        Listeners.Remove(listener);
    }
}
