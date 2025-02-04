using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//using static UnityEditor.Progress;

public class InventorySlot : MonoBehaviour
{
    public PlayerController player; //экземпляр класса персонажа

    public Transform playerTransform; // Ссылка на игрока

    public float spawnDistance = 2.0f; // Расстояние от игрока, на котором будет спавниться предмет

    public ItemScriptableObject item;

    public ItemFood foodItem;
    public int amount;
    public Sprite spriteSlot;
    public GameObject spriteSlotPanel;

    public GameObject panelSlot;
    public Sprite nullPanelSlot;

    public TextMeshProUGUI textAmount;

    public TextMeshProUGUI Description;
    public TextMeshProUGUI textName;
    public bool isEmpty => item == null || amount <= 0; // Слот считается пустым, если нет предмета или количество равно нулю
    public bool panelSlotIsOpen = false;

    private static InventorySlot currentlyOpenPanel; // Ссылка на открытую панель

    public Button useButton; //ссылка на кнопку use 

    public bool isDefault;
    public bool isWeapons;
    public bool isFood;
    public bool isTool;

    public void ClearSprite()
    {
        item = null; // Убираем ссылку на предмет
        amount = 0; // Сбрасываем количество
        gameObject.GetComponent<Image>().sprite = null; // Очищаем спрайт
        
    }
    public void Start()
    {
        player = FindObjectOfType<PlayerController>();
        if(panelSlot != null )
        {
            panelSlot.SetActive(false);
        }
        UpdateText();

        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(TogglePanel);
        }
        //if (useButton != null)
        //{
            //useButton.onClick.AddListener(() => UseButton());
        //}

        
    }

    public void Update()
    {
        UpdateText();
        UIchecker();
        
    }

    private void UpdateText()
    {
        textAmount.text = amount.ToString();
        textAmount.gameObject.SetActive(amount > 0);
    }

    void TogglePanel()
    {
        if (panelSlotIsOpen)
        {
            // Если панель уже открыта, просто закрываем её
            ClosePanel();
        }
        else
        {
            // Если другая панель уже открыта, ничего не делаем
            if (currentlyOpenPanel != null)
            {
                return; // Не разрешаем открывать другую панель, пока одна открыта
            }

            // Открываем текущую панель
            OpenPanel();
        }
    }

    void OpenPanel()
    {
        GetItemTypeOnSlot();
        panelSlotIsOpen = true;
        panelSlot.SetActive(true);
        currentlyOpenPanel = this; // Устанавливаем текущую открытую панель
        spriteSlotPanel.GetComponent<Image>().sprite = item.itemSprite;
        Description.text = item.itemDescription;
        textName.text = item.itemShowName;


        // Блокируем все остальные кнопки
        BlockOtherButtons(true);
    }

    void ClosePanel()
    {
        panelSlotIsOpen = false;
        panelSlot.SetActive(false);

        // Если мы закрываем панель, сбрасываем ссылку на открытую панель
        if (currentlyOpenPanel == this)
        {
            currentlyOpenPanel = null;
        }

        // Разблокируем все кнопки
        BlockOtherButtons(false);
    }

    private void BlockOtherButtons(bool block)
    {
        // Получаем все компоненты InventorySlot в сцене
        InventorySlot[] allSlots = FindObjectsOfType<InventorySlot>();

        foreach (var slot in allSlots)
        {
            if (slot != this) // Пропускаем текущий слот
            {
                Button button = slot.GetComponent<Button>();
                if (button != null)
                {
                    button.interactable = !block; // Блокируем или разблокируем кнопку
                }
            }
        }
    }
    public void DropButton()
    {
        float rand = UnityEngine.Random.Range(-0.8f, 0.8f); // Используем Random.Range для получения случайного значения
        float rand2 = UnityEngine.Random.Range(-0.8f, 0.8f);
        Vector3 transformDrop = new Vector3(playerTransform.position.x + rand, playerTransform.position.y + 0.2f, playerTransform.position.z + rand2);
        if (amount > 0)
        {
            Instantiate(item.itemPrefab, transformDrop, playerTransform.rotation);
            amount--;
            print("кнопка нажата");
        }

    }
    public void UseButton()
    {
        PlayerController player = FindObjectOfType<PlayerController>();

        if (player != null && item.isFood == true)
        {
            // Используем предмет на игроке
            if (item.isUsed)
            {
                player.healthPlayer += item.health;
                player.hungryPlayer += item.hungry;
                AudioManager.instance.Play("eatSound");
                amount--;
            }
            else
            {
                Debug.Log("Item cannot be used.");
            }
        }
        else
        {
            Debug.LogError("PlayerController not found in the scene!");
        }
    }
    public void UIchecker()
    {
        if (amount == 0)
        {
            gameObject.GetComponent<Image>().sprite = nullPanelSlot;
            if(spriteSlotPanel != null)
            {
                spriteSlotPanel.GetComponent<Image>().sprite = nullPanelSlot;
            }
        }

    }
    void SpawnItem()
    {
        // Получаем позицию игрока
        //Vector3 playerPosition = playerTransform;

        // Вычисляем новую позицию для предмета
        //Vector3 spawnPosition = playerPosition + Random.onUnitSphere * spawnDistance;
        //spawnPosition.y = playerPosition.y; // Убедитесь, что предмет спавнится на той же высоте

        // Создаем предмет
        //Instantiate(item.itemPrefab, spawnPosition, Quaternion.identity);
    }
    public void GetItemTypeOnSlot()
    {
        if (item != null)
        {
            if (item.isDefault)
            {
                isDefault = true;

                isWeapons = false;
                isFood = false;
                isTool = false;

            }
            else if (item.isWeapons)
            {
                isWeapons = true;

                isFood = false;
                isTool = false;
                isDefault = false;
            }
            else if (item.isFood)
            {
                isFood = true;

                isTool = false;
                isWeapons = false;
                isDefault = true;
            }
            else if (item.isTool)
            {
                isTool = true;

                isWeapons = false;
                isDefault = true;
                isFood = false;
            }
        }
    }
}
