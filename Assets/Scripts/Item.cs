using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public ItemScriptableObject item;
    public int amount; //������� ���-�� ��������� �� ���������
    public GameObject itemGO;
    public Sprite spriteItem;
    public bool isDelete = false;

    public bool isPicked;

    public bool thisIsBush; //���������� ���� ��� ����������� ������

    public GameObject nullBushGO; //������ (���������) ����
    public bool itemReady; //������� ����� � ����� � ���������
    public bool isCorountineStart = false;

    private void Start()
    {
         
    }
    public void Update()
    {
        if (isDelete && !thisIsBush)
        {
            Destroy(this.gameObject);
        }

        if (thisIsBush && isPicked && !isCorountineStart) // ��������� ������� ��� �������� isCorountineStart
        {
            BushGrow();
        }
    }

    public void BushGrow() // ���� �����
    {
        isCorountineStart = true;
        StartCoroutine(GrowingBush());
    }

    public IEnumerator GrowingBush()
    {
        Debug.Log("�������� ���� �����");
        ReplaceWithNullBush();
        yield return new WaitForSeconds(5f);
        ReplaceWithFullBush();
        Debug.Log("���� �����");
        isPicked = false;
        isCorountineStart = false; // ���������� ���� ����� ���������� ��������
    }
    private void ReplaceWithNullBush()
    {
        print("�������� ����������");
        nullBushGO = gameObject;
    }
    private void ReplaceWithFullBush()
    {
        print("�������� ���������� 2");
        itemGO = gameObject;
    }

}
