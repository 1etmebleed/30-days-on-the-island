using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
//using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    public GameObject UIpanel;
    public GameObject UIpanel2; //���������� ������ ���������
    public GameObject quickPanel;
    public Transform inventoryPanel; //������� ������ ������ ���������
    public List<InventorySlot> slots = new List<InventorySlot>();

    public bool isOpen = false;

    public ItemScriptableObject currentItem; // ������ �� ������� �������

    public Item _item; 

    private bool isInTrigger = false;

    public Inventory inventory; // ������ �� ���������

    public Collider colliderPickup; //��������� ������� ��������� 

    public bool itemIsReady = false;

    public GameObject[] spritesGear; //������� ������ ����������

    public GameObject CraftSlot; //image UI GO ���� ������� ��������� ���� ������

    public GameObject GuideSlot; //image UI GO ���� ������� ��������� ���� ���� ������

    public GameObject HealthImage; // ������ ��

    public GameObject HungryImage; //������ ���

    void Start()
    {
        inventory = FindObjectOfType<Inventory>(); // �������� ������ �� ���������
        for (int i=0; i< inventoryPanel.childCount; i++)
        {
            if( inventoryPanel.GetChild(i).GetComponent<InventorySlot>() != null )
            {
                slots.Add(inventoryPanel.GetChild(i).GetComponent<InventorySlot>());
            }
        }
        UIpanel.SetActive(false);
        UIpanel2.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Tab))
        {
            isOpen = !isOpen;
            if(isOpen)
            {
                AudioManager.instance.Play("openBackpack");
                UIpanel.SetActive(true);
                UIpanel2.SetActive(true);
                quickPanel.SetActive(false);
                Cursor.lockState = CursorLockMode.Confined; // ������������ ������
                CraftSlot.SetActive(true);
                GuideSlot.SetActive(true);
                HealthImage.SetActive(false);
                HungryImage.SetActive(false);

                for (int i =0; i<spritesGear.Length;i++)
                {
                    spritesGear[i].SetActive(true);
                }
            }
            else
            {
                AudioManager.instance.Play("closeBackpack");
                UIpanel.SetActive(false);
                UIpanel2.SetActive(false);
                quickPanel.SetActive(true);
                Cursor.lockState = CursorLockMode.Locked; // ��������� ������
                CraftSlot.SetActive(false);
                GuideSlot.SetActive(false);
                HealthImage.SetActive(true);
                HungryImage.SetActive(true);

                for (int i = 0; i < spritesGear.Length; i++)
                {
                    spritesGear[i].SetActive(false);
                }
            }
        }
        if (isInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            if (currentItem != null && itemIsReady == true && _item.itemReady==true)
            {
                AudioManager.instance.Play("pickupItemSound");
                Debug.Log("������ �����������");
                AddItem(currentItem, 1); // ��������� 1 ��������� �������� � ���������
                _item.isPicked = true;
                _item.isDelete = true;
                currentItem = null; // ���������� currentItem ����� ���������� � ���������
            }
            else
            {
                Debug.Log("currentItem ����� null");
            }
        }
    }
    public void AddItem(ItemScriptableObject item, int amount)
    {
        // �������� �� ������������� �������� � ���������
        foreach (InventorySlot slot in slots)
        {
            Debug.Log("�������� �����: " + (slot.item != null ? slot.item.name : "null") + " �� ��������� � " + item.name);
            if (slot.item == item)
            {
                slot.amount += amount; // ����������� ����������
                
                return; // ������� ��� ��������
            }
        }

        // ���� �������� ���, ���� ������ ����
        foreach (InventorySlot slot in slots)
        {
            Debug.Log("�������� �� ������� �����: " + slot.isEmpty);
            if (slot.isEmpty) // ���� ���� ������
            {
                if(_item.spriteItem == null)
                {
                    return;
                }
                slot.gameObject.GetComponent<Image>().sprite = _item.spriteItem;
                slot.item = item; // ��������� �������
                slot.amount = amount; // ������������� ����������
                
                Debug.Log("������� � ������: " + item.name);
                return; // ������� �������� �������
            }
            else
            {
                Debug.Log("���� �� ������: " + slot.item.name);
            }
        }

        Debug.Log("��� ��������� ������ ��� ���������� ��������: " + item.name);
    }
    private void OnTriggerEnter(Collider other)
    {
        _item = other.GetComponent<Item>();
        if (other.CompareTag("Item"))
        {
            Item itemComponent = other.GetComponent<Item>();
            if(_item.isOutlined == true)
            {
                _item.outline.enabled = true;
            }
            if (itemComponent != null)
            {
                currentItem = itemComponent.item; // ������������, ��� itemData - ��� ��� ItemScriptableObject
                itemIsReady = true;
                isInTrigger = true; // ������������� ����, ��� ����� � ��������
                Debug.Log("������ ����� � �������: " + other.name);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            if (_item.isOutlined == true)
            {
                _item.outline.enabled = false;
            }
            isInTrigger = false; // ���������� ���� ��� ������ �� ��������
            itemIsReady = false;
            currentItem = null; // ���������� ������� �������
            _item = null;
            Debug.Log("������ ����� �� ��������: " + other.name);
        }
    }

}
