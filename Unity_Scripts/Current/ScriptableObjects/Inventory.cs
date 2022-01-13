using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory: ScriptableObject
{  
    public Item currentItem;
    public List<Item> items = new List<Item>();
    public int keycount;

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
