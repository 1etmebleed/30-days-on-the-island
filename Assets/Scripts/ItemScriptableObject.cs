using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Progress;

public enum Itemtype { Default, Weapons, Food, Tool }
public class ItemScriptableObject : ScriptableObject
{
    public bool isUsed = false; //если включено, то предмет можно использовать через инвентарь
    public Itemtype itemType;
    public GameObject itemGO; //префаб предмета
    public Sprite itemSprite; // Иконка предмета
    static public string itemName; //Название предмета   
    public string itemShowName; //отображаемое имя предмета в инвентаре
    public int maxAmount;
    public string itemDescription;
    public GameObject itemPrefab;
}
