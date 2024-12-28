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


    public void Update()
    {
        if(isDelete == true)
        {
            Destroy(this.gameObject);
        }
    }

}
