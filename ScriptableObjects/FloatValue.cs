using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatValue : ScriptableObject, ISerializationCallbackReceiver
{   
    public float initialValue;

    [HideInInspector]
    public float runtimevalue;

    public void OnAfterDeserialize(){
        runtimevalue = initialValue;
    } 

    public void OnBeforeSerialize(){} 
}
