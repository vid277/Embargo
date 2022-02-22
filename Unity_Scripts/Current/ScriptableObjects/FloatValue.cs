/*

@Author Vidyoot Senthilvenkatesh
@Version 2/21/2022

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Creates a scriptable object*/
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
