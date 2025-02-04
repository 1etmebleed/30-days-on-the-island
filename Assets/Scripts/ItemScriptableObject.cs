using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Progress;

public enum Itemtype { Default, Weapons, Food, Tool }
public class ItemScriptableObject : ScriptableObject
{
    public int id;

    [Header("Тип обьекта ТОЛЬКО ОДИН!")]
    public bool isDefault;
    public bool isWeapons;
    public bool isFood;
    public bool isTool;

    [Header("Общие настройки")]
    public bool isUsed = false; //если включено, то предмет можно использовать через инвентарь
    public Itemtype itemType;
    public GameObject itemGO; //префаб предмета
    public Sprite itemSprite; // Иконка предмета
    static public string itemName; //Название предмета   
    public string itemShowName; //отображаемое имя предмета в инвентаре
    public int maxAmount;
    public string itemDescription;
    public GameObject itemPrefab;

    [Header("Настройки для еды, если это еда!")]
    public int health;
    public int hungry;
    public string[] nameForCook;


    [Header("Настройки для инструмента, если это инструмент!")]
    public int endurance; //прочность

    [Header("Настройки для оружия, если это оружие!")]
    public int damage; //урон


}
