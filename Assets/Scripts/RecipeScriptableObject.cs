using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "recipe", menuName = "Inventory/recipe/New recipe")]

public class RecipeScriptableObject : ScriptableObject
{

    public string profession; //��������� ����������� ��� ������, ���� ����������
    public string skull; //����� ����������� ��� ������, ���� ����������

    [Range(1, 3)] // ������������ �������� �� 1 �� 3
    [SerializeField] public int countComponent;

    public ItemScriptableObject[] foodComponents1; //���������� ����� 1
    [Range(1, 99)] // ������������ �������� �� 1 �� 3
    public int foodNeedCount1;

    public ItemScriptableObject[] foodComponents2; //���������� ����� 2
    [Range(1, 99)] // ������������ �������� �� 1 �� 3
    public int foodNeedCount2;

    public ItemScriptableObject[] foodComponents3; //���������� ����� 3
    [Range(1, 99)] // ������������ �������� �� 1 �� 3
    public int foodNeedCount3;

    public ItemScriptableObject resultCook; //������� �����



    public int foodCountCooked; //������� ���� ������������ 

    public Sprite sprite; //������ 

    public Sprite[] spritesTags; //������� ��� ����������� �����

    public string description; //�������� �����

    public string title; //�������� �����

    public string[] buffTags; //������ ������ �����

    public int hungry; //����� ����������� ������

    public int health; //����� ����������� ��������
}
