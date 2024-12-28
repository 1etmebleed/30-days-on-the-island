using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Food Item",menuName = "Inventory/Items/New Food Item")]
public class ItemFood : ItemScriptableObject
{
    public int health;
    public int hungry;

    public void Start()
    {
        itemType = Itemtype.Food;
    }
}
