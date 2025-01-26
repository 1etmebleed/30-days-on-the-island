using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Progress;

public enum Itemtype { Default, Weapons, Food, Tool }
public class ItemScriptableObject : ScriptableObject
{
    [Header("��� ������� ������ ����!")]
    public bool isDefault;
    public bool isWeapons;
    public bool isFood;
    public bool isTool;

    [Header("����� ���������")]
    public bool isUsed = false; //���� ��������, �� ������� ����� ������������ ����� ���������
    public Itemtype itemType;
    public GameObject itemGO; //������ ��������
    public Sprite itemSprite; // ������ ��������
    static public string itemName; //�������� ��������   
    public string itemShowName; //������������ ��� �������� � ���������
    public int maxAmount;
    public string itemDescription;
    public GameObject itemPrefab;

    [Header("��������� ��� ���, ���� ��� ���!")]
    public int health;
    public int hungry;


    [Header("��������� ��� �����������, ���� ��� ����������!")]
    public int endurance; //���������

    [Header("��������� ��� ������, ���� ��� ������!")]
    public int damage; //����


}
