using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Campfire : MonoBehaviour
{
    public bool isReady = false;

    public GameObject cookingPanel;

    public GameManager gameManager;

    public InventorySlot[] inventorySlots; // Массив слотов инвентаря
    public GameObject itemPrefab; // Префаб для отображения предмета

    public ItemScriptableObject item;

    void Start()
    {
        // Инициализация, если необходимо
    }

    void Update()
    {
        if (!isReady)
        {
            gameManager.panelCook.SetActive(false);
        }
        GoCook();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isReady = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isReady = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void GoCook()
    {
        if (isReady && Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(gameManager.CheckAllRecipesCoroutine());
            
            Cursor.lockState = CursorLockMode.Confined;
            AudioManager.instance.Play("openBackpack");
            gameManager.panelCook.SetActive(true);
            UpdateCookingPanel(); // Обновляем панель готовки при открытии
            
        }
    }

    public void UpdateCookingPanel()
    {
        ClearCookingPanel(); // Очистка панели перед обновлением

        foreach (InventorySlot slot in inventorySlots)
        {
            if (slot.item != null && slot.item.isFood) // Проверяем, что предмет — еда
            {
                item = slot.item;
                AddToCookingPanel(slot.item, slot.amount);
                item = null;
            }
        }
    }

    private void ClearCookingPanel()
    {
        foreach (Transform child in cookingPanel.transform)
        {
            Destroy(child.gameObject); // Удаляем старые элементы
        }
    }

    private void AddToCookingPanel(ItemScriptableObject item, int amount)
    {
        GameObject newItem = Instantiate(itemPrefab); // Создаем новый элемент UI
        newItem.GetComponent<Image>().sprite = item.itemSprite; // Устанавливаем спрайт
        newItem.transform.SetParent(cookingPanel.transform); // Устанавливаем родителем панель готовки

        // Добавляем текст или другой UI элемент для отображения количества
        TextMeshProUGUI amountText = newItem.GetComponentInChildren<TextMeshProUGUI>();
        if (amountText != null)
        {
            amountText.text = amount.ToString();
        }

        Debug.Log("Добавил предмет на панель готовки: " + item.name);
    }
}