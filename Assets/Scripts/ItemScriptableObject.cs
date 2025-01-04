using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Progress;

public enum Itemtype { Default, Weapons, Food, Tool }
public class ItemScriptableObject : ScriptableObject
{
    public bool isUsed = false; //���� ��������, �� ������� ����� ������������ ����� ���������
    public Itemtype itemType;
    public GameObject itemGO; //������ ��������
    public Sprite itemSprite; // ������ ��������
    static public string itemName; //�������� ��������   
    public string itemShowName; //������������ ��� �������� � ���������
    public int maxAmount;
    public string itemDescription;
    public GameObject itemPrefab;
}
