/*

@Author Vidyoot Senthilvenkatesh
@Version 2/21/2022

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Creates a scriptable object*/
[CreateAssetMenu]
public class Item : ScriptableObject  {

    public Sprite itemSprite;
    public string itemDescription;
    public bool isKey;

}