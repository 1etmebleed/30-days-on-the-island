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

    public InventorySlot[] inventorySlots; // ������ ������ ���������
    public GameObject itemPrefab; // ������ ��� ����������� ��������

    public ItemScriptableObject item;

    void Start()
    {
        // �������������, ���� ����������
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
            UpdateCookingPanel(); // ��������� ������ ������� ��� ��������
            
        }
    }

    public void UpdateCookingPanel()
    {
        ClearCookingPanel(); // ������� ������ ����� �����������

        foreach (InventorySlot slot in inventorySlots)
        {
            if (slot.item != null && slot.item.isFood) // ���������, ��� ������� � ���
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
            Destroy(child.gameObject); // ������� ������ ��������
        }
    }

    private void AddToCookingPanel(ItemScriptableObject item, int amount)
    {
        GameObject newItem = Instantiate(itemPrefab); // ������� ����� ������� UI
        newItem.GetComponent<Image>().sprite = item.itemSprite; // ������������� ������
        newItem.transform.SetParent(cookingPanel.transform); // ������������� ��������� ������ �������

        // ��������� ����� ��� ������ UI ������� ��� ����������� ����������
        TextMeshProUGUI amountText = newItem.GetComponentInChildren<TextMeshProUGUI>();
        if (amountText != null)
        {
            amountText.text = amount.ToString();
        }

        Debug.Log("������� ������� �� ������ �������: " + item.name);
    }
}