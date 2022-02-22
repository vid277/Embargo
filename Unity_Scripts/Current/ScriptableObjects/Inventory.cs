/*

@Author Vidyoot Senthilvenkatesh
@Version 2/21/2022

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory: ScriptableObject
{  
    public Item currentItem;
    public List<Item> items = new List<Item>();
    public int keycount;
/*Adds items to theh player's inventory and increases the amount if an item of the same type is present*/
    public void AddItem(Item itemtoAdd){
        if(itemtoAdd.isKey){
            keycount++;
        }
        else{
            if(!items.Contains(itemtoAdd)){
                items.Add(itemtoAdd);
            }
        }
    }
}
