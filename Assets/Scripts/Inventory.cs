using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
//using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    public Transform inventoryPanel; //Игровой объект панели инвентаря
    public List<InventorySlot> slots = new List<InventorySlot>();

    public bool isOpen = false;

    public ItemScriptableObject currentItem; // Ссылка на текущий предмет

    public Item _item; 

    private bool isInTrigger = false;

    public Inventory inventory; // Ссылка на инвентарь

    public Collider colliderPickup; //Коллайдер подбора предметов 

    public bool itemIsReady = false;

    public GameObject[] spritesGear; //спрайты слотов снаряжения

    public GameObject[] ElementsInventory;//элементы UI которые скрываются при нажатии tab

    public GameObject[] ElementsCraft;

    public GameObject[] ElementsStats;

    public GameObject[] ElementsGuide;

    public GameObject GlobalPanel;

    public GameObject QuickPanel;


    void Start()
    {
        inventory = FindObjectOfType<Inventory>(); // Получаем ссылку на инвентарь
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
                Cursor.lockState = CursorLockMode.Confined; // разблокируем курсор


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
                Cursor.lockState = CursorLockMode.Locked; // Блокируем курсор


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
                Debug.Log("ЛОГИКА ВЫПОЛНЯЕТСЯ");
                AddItem(currentItem, 1); // Добавляем 1 экземпляр предмета в инвентарь
                _item.isPicked = true;
                _item.isDelete = true;
                currentItem = null; // Сбрасываем currentItem после добавления в инвентарь
            }
            else
            {
                Debug.Log("currentItem равен null");
            }
        }
    }
    public void AddItem(ItemScriptableObject item, int amount)
    {
        // Проверка на существование предмета в инвентаре
        foreach (InventorySlot slot in slots)
        {
            Debug.Log("Проверка слота: " + (slot.item != null ? slot.item.name : "null") + " на равенство с " + item.name);
            if (slot.item == item)
            {
                slot.amount += amount; // Увеличиваем количество
                
                return; // Предмет уже добавлен
            }
        }

        // Если предмета нет, ищем пустой слот
        foreach (InventorySlot slot in slots)
        {
            Debug.Log("Проверка на пустоту слота: " + slot.isEmpty);
            if (slot.isEmpty) // Если слот пустой
            {
                if(_item.spriteItem == null)
                {
                    return;
                }
                slot.gameObject.GetComponent<Image>().sprite = _item.spriteItem;
                slot.item = item; // Добавляем предмет
                slot.amount = amount; // Устанавливаем количество
                
                Debug.Log("Добавил в ячейку: " + item.name);
                return; // Успешно добавили предмет
            }
            else
            {
                Debug.Log("Слот не пустой: " + slot.item.name);
            }
        }

        Debug.Log("Нет свободных слотов для добавления предмета: " + item.name);
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
                currentItem = itemComponent.item; // Предполагаем, что itemData - это ваш ItemScriptableObject
                itemIsReady = true;
                isInTrigger = true; // Устанавливаем флаг, что игрок в триггере
                Debug.Log("Объект вошел в триггер: " + other.name);
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
            isInTrigger = false; // Сбрасываем флаг при выходе из триггера
            itemIsReady = false;
            currentItem = null; // Сбрасываем текущий предмет
            _item = null;
            Debug.Log("Объект вышел из триггера: " + other.name);
        }
    }

    public void ButtonInventory()
    {
        //выключаем
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
        //включаем
        for (int i = 0; i < ElementsInventory.Length; i++)
        {
            ElementsInventory[i].SetActive(true);
        }
    }

    public void ButtonCraft()
    {
        //выключаем
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
        //включаем
        for (int i = 0; i < ElementsCraft.Length; i++)
        {
            ElementsCraft[i].SetActive(true);
        }
    }
    public void ButtonGuide()
    {
        //выключаем
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
        //включаем
        for (int i = 0; i < ElementsGuide.Length; i++)
        {
            ElementsGuide[i].SetActive(true);
        }
    }
    public void ButtonStats()
    {
        //выключаем
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
        //включаем
        for (int i = 0; i < ElementsStats.Length; i++)
        {
            ElementsStats[i].SetActive(true);
        }
    }
}
