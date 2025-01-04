using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
//using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
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

    public GameObject[] ElementsInventory;//�������� UI ������� ���������� ��� ������� tab

    public GameObject[] ElementsCraft;

    public GameObject[] ElementsStats;

    public GameObject[] ElementsGuide;

    public GameObject GlobalPanel;

    public GameObject QuickPanel;


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
        GlobalPanel.SetActive(false);
        QuickPanel.SetActive(true);

        
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Tab))
        {
            isOpen = !isOpen;
            if(isOpen)
            {
                QuickPanel.SetActive(false);
                AudioManager.instance.Play("openBackpack");
                GlobalPanel.SetActive(true);
                Cursor.lockState = CursorLockMode.Confined; // ������������ ������


                for (int i =0; i<spritesGear.Length;i++)
                {
                    spritesGear[i].SetActive(true);
                }
            }
            else
            {
                QuickPanel.SetActive(true);
                AudioManager.instance.Play("closeBackpack");
                GlobalPanel.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked; // ��������� ������


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

    public void ButtonInventory()
    {
        //���������
        for (int i = 0; i < ElementsCraft.Length; i++)
        {
            ElementsCraft[i].SetActive(false);
        }
        for (int i = 0; i < ElementsStats.Length; i++)
        {
            ElementsStats[i].SetActive(false);
        }
        for(int i = 0;i<ElementsGuide.Length; i++)
        {
            ElementsGuide[i].SetActive(false);
        }
        //��������
        for (int i = 0; i < ElementsInventory.Length; i++)
        {
            ElementsInventory[i].SetActive(true);
        }
    }

    public void ButtonCraft()
    {
        //���������
        for (int i = 0; i < ElementsGuide.Length; i++)
        {
            ElementsGuide[i].SetActive(false);
        }
        for (int i = 0; i < ElementsStats.Length; i++)
        {
            ElementsStats[i].SetActive(false);
        }
        for(int i = 0;i<ElementsInventory.Length; i++)
        {
            ElementsInventory[i].SetActive(false);
        }
        //��������
        for (int i = 0; i < ElementsCraft.Length; i++)
        {
            ElementsCraft[i].SetActive(true);
        }
    }
    public void ButtonGuide()
    {
        //���������
        for (int i = 0; i < ElementsStats.Length; i++)
        {
            ElementsStats[i].SetActive(false);
        }
        for (int i = 0; i < ElementsInventory.Length; i++)
        {
            ElementsInventory[i].SetActive(false);
        }
        for (int i = 0; i < ElementsCraft.Length; i++)
        {
            ElementsCraft[i].SetActive(false);
        }
        //��������
        for (int i = 0; i < ElementsGuide.Length; i++)
        {
            ElementsGuide[i].SetActive(true);
        }
    }
    public void ButtonStats()
    {
        //���������
        for (int i = 0; i < ElementsInventory.Length; i++)
        {
            ElementsInventory[i].SetActive(false);
        }
        for (int i = 0; i < ElementsCraft.Length; i++)
        {
            ElementsCraft[i].SetActive(false);
        }
        for (int i = 0; i < ElementsGuide.Length; i++)
        {
            ElementsGuide[i].SetActive(false);
        }
        //��������
        for (int i = 0; i < ElementsStats.Length; i++)
        {
            ElementsStats[i].SetActive(true);
        }
    }
}
