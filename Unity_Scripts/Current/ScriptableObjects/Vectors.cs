/*

@Author Vidyoot Senthilvenkatesh
@Version 2/21/2022

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Creates vector assets*/
[CreateAssetMenu]
public class Vectors : ScriptableObject, ISerializationCallbackReceiver
{   
    public Vector2 initialValue;
    public Vector2 defaultValue;

    public void OnAfterDeserialize(){ initialValue = defaultValue;}

    public void OnBeforeSerialize(){}
}
