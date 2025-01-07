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
    public PlayerController player; //��������� ������ ���������

    public Transform playerTransform; // ������ �� ������

    public float spawnDistance = 2.0f; // ���������� �� ������, �� ������� ����� ���������� �������

    public ItemScriptableObject item;

    public ItemFood foodItem;
    public int amount;
    public Sprite spriteSlot;
    public GameObject spriteSlotPanel;

    public GameObject panelSlot;
    public Sprite nullPanelSlot;

    public TextMeshProUGUI text;

    public TextMeshProUGUI Description;
    public bool isEmpty => item == null || amount <= 0; // ���� ��������� ������, ���� ��� �������� ��� ���������� ����� ����
    public bool panelSlotIsOpen = false;

    private static InventorySlot currentlyOpenPanel; // ������ �� �������� ������

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
            // ���� ������ ��� �������, ������ ��������� �
            ClosePanel();
        }
        else
        {
            // ���� ������ ������ ��� �������, ������ �� ������
            if (currentlyOpenPanel != null)
            {
                return; // �� ��������� ��������� ������ ������, ���� ���� �������
            }

            // ��������� ������� ������
            OpenPanel();
        }
    }

    void OpenPanel()
    {
        panelSlotIsOpen = true;
        panelSlot.SetActive(true);
        currentlyOpenPanel = this; // ������������� ������� �������� ������
        spriteSlotPanel.GetComponent<Image>().sprite = item.itemSprite;
        Description.text = item.itemDescription;


        // ��������� ��� ��������� ������
        BlockOtherButtons(true);
    }

    void ClosePanel()
    {
        panelSlotIsOpen = false;
        panelSlot.SetActive(false);

        // ���� �� ��������� ������, ���������� ������ �� �������� ������
        if (currentlyOpenPanel == this)
        {
            currentlyOpenPanel = null;
        }

        // ������������ ��� ������
        BlockOtherButtons(false);
    }

    private void BlockOtherButtons(bool block)
    {
        // �������� ��� ���������� InventorySlot � �����
        InventorySlot[] allSlots = FindObjectsOfType<InventorySlot>();

        foreach (var slot in allSlots)
        {
            if (slot != this) // ���������� ������� ����
            {
                Button button = slot.GetComponent<Button>();
                if (button != null)
                {
                    button.interactable = !block; // ��������� ��� ������������ ������
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
        // �������� ������� ������
        //Vector3 playerPosition = playerTransform;

        // ��������� ����� ������� ��� ��������
        //Vector3 spawnPosition = playerPosition + Random.onUnitSphere * spawnDistance;
        //spawnPosition.y = playerPosition.y; // ���������, ��� ������� ��������� �� ��� �� ������

        // ������� �������
        //Instantiate(item.itemPrefab, spawnPosition, Quaternion.identity);
    }
}
