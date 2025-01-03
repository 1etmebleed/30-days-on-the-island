using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
//using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    public GameObject UIpanel;
    public GameObject UIpanel2; //прозрачная панель инвентаря
    public GameObject quickPanel;
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

    public GameObject CraftSlot; //image UI GO слот который открывает меню крафта

    public GameObject GuideSlot; //image UI GO слот который открывает меню гайд книжки

    public GameObject HealthImage; // иконка хп

    public GameObject HungryImage; //иконка еды

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
                Cursor.lockState = CursorLockMode.Confined; // разблокируем курсор
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
                Cursor.lockState = CursorLockMode.Locked; // Блокируем курсор
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

}
