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

    public TextMeshProUGUI text;

    public TextMeshProUGUI Description;
    public bool isEmpty => item == null || amount <= 0; // Слот считается пустым, если нет предмета или количество равно нулю
    public bool panelSlotIsOpen = false;

    private static InventorySlot currentlyOpenPanel; // Ссылка на открытую панель

    public void Start()
    {
        panelSlot.SetActive(false);
        UpdateText();

        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(TogglePanel);
        }
    }

    public void Update()
    {
        UpdateText();
        UIchecker();
    }

    private void UpdateText()
    {
        text.text = amount.ToString();
        text.gameObject.SetActive(amount > 0);
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
        panelSlotIsOpen = true;
        panelSlot.SetActive(true);
        currentlyOpenPanel = this; // Устанавливаем текущую открытую панель
        spriteSlotPanel.GetComponent<Image>().sprite = item.itemSprite;
        Description.text = item.itemDescription;


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
        if(amount > 0)
        {
            Instantiate(item.itemPrefab, transform.position, transform.rotation);
            amount--;
        }

    }
    public void UseButton()
    {
        if(item.isUsed == true && amount > 0)
        {
            amount--;
            player.healthPlayer += foodItem.health;
            player.hungryPlayer += foodItem.hungry;
        }
    }
    public void UIchecker()
    {
        if (amount == 0)
        {
            gameObject.GetComponent<Image>().sprite = nullPanelSlot;
            spriteSlotPanel.GetComponent<Image>().sprite = nullPanelSlot;
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
}
