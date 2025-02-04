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

    public TextMeshProUGUI textAmount;

    public TextMeshProUGUI Description;
    public TextMeshProUGUI textName;
    public bool isEmpty => item == null || amount <= 0; // ���� ��������� ������, ���� ��� �������� ��� ���������� ����� ����
    public bool panelSlotIsOpen = false;

    private static InventorySlot currentlyOpenPanel; // ������ �� �������� ������

    public Button useButton; //������ �� ������ use 

    public bool isDefault;
    public bool isWeapons;
    public bool isFood;
    public bool isTool;

    public void ClearSprite()
    {
        item = null; // ������� ������ �� �������
        amount = 0; // ���������� ����������
        gameObject.GetComponent<Image>().sprite = null; // ������� ������
        
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
        GetItemTypeOnSlot();
        panelSlotIsOpen = true;
        panelSlot.SetActive(true);
        currentlyOpenPanel = this; // ������������� ������� �������� ������
        spriteSlotPanel.GetComponent<Image>().sprite = item.itemSprite;
        Description.text = item.itemDescription;
        textName.text = item.itemShowName;


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
        float rand = UnityEngine.Random.Range(-0.8f, 0.8f); // ���������� Random.Range ��� ��������� ���������� ��������
        float rand2 = UnityEngine.Random.Range(-0.8f, 0.8f);
        Vector3 transformDrop = new Vector3(playerTransform.position.x + rand, playerTransform.position.y + 0.2f, playerTransform.position.z + rand2);
        if (amount > 0)
        {
            Instantiate(item.itemPrefab, transformDrop, playerTransform.rotation);
            amount--;
            print("������ ������");
        }

    }
    public void UseButton()
    {
        PlayerController player = FindObjectOfType<PlayerController>();

        if (player != null && item.isFood == true)
        {
            // ���������� ������� �� ������
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
        // �������� ������� ������
        //Vector3 playerPosition = playerTransform;

        // ��������� ����� ������� ��� ��������
        //Vector3 spawnPosition = playerPosition + Random.onUnitSphere * spawnDistance;
        //spawnPosition.y = playerPosition.y; // ���������, ��� ������� ��������� �� ��� �� ������

        // ������� �������
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
