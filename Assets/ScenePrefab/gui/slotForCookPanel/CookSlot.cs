using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;


public class CookSlot : MonoBehaviour
{
    public CookSlot cookSlot;

    public bool isReady;

    public bool deleteFlag = false;

    public RecipeScriptableObject recipe;

    public Inventory inventory; 

    public GameObject GameObject1;

    private List<InventorySlot> slots; // ������ ������������� List

    public ItemScriptableObject[] components; //������� ��� ����� ��������� �� ���


    [Header("�� �������")]
    public int readyCount1;
    public int readyCount2;
    public int readyCount3;

    List<InventorySlot> slotsForNull = new List<InventorySlot>();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FindFoodComponents()
    {
        readyCount1 = 0; // ����� ����� �������
        isReady = false; // ����� ����� �������

        if (recipe.countComponent == 1)
        {
            print("��� ������� ��� �����������!!!!!!!!!!!!!!!" + recipe.countComponent);
            for (int i = 0; i < inventory.slots.Count; i++)
            {
                for (int j = 0; j < recipe.foodComponents1.Length; j++)
                {
                    if (inventory.slots[i].item == recipe.foodComponents1[j])
                    {
                        slotsForNull.Add(inventory.slots[i]);
                        readyCount1++;
                        Debug.Log($"������ ���������: {inventory.slots[i].item}. ������� �������: {readyCount1}");
                        if (readyCount1 >= recipe.foodNeedCount1) // ���������� >= �� ������, ���� ������ ������� ����������
                        {
                            isReady = true;
                            Debug.Log("���������� �����������! ������.");
                            break; // ������� �� ����������� �����, ���� ��� ���������� �����������
                        }
                    }
                }
                if (isReady) break; // ������� �� �������� �����, ���� ��� ���������� �����������
            }
        }
        if (recipe.countComponent == 2)
        {
            print("��� ������� ��� �����������!!!!!!!!!!!!!!!" + recipe.countComponent);
            for (int i = 0; i < inventory.slots.Count; i++)
            {
                for (int j = 0; j < recipe.foodComponents1.Length; j++)
                {
                    if (inventory.slots[i].item == recipe.foodComponents1[j])
                    {
                        slotsForNull.Add(inventory.slots[i]);
                        readyCount1++;
                        Debug.Log($"������ ���������: {inventory.slots[i].item}. ������� �������: {readyCount1}");
                        if (readyCount1 >= recipe.foodNeedCount1) // ���������� >= �� ������, ���� ������ ������� ����������
                        {
                            isReady = true;
                            Debug.Log("���������� �����������! ������.");
                            break; // ������� �� ����������� �����, ���� ��� ���������� �����������
                        }
                    }
                }
            }
            for (int i = 0; i < inventory.slots.Count; i++)
            {
                for (int j = 0; j < recipe.foodComponents2.Length; j++)
                {
                    if (inventory.slots[i].item == recipe.foodComponents2[j])
                    {
                        slotsForNull.Add(inventory.slots[i]);
                        readyCount2++;
                        Debug.Log($"������ ���������: {inventory.slots[i].item}. ������� �������: {readyCount2}");
                        if (readyCount1 >= recipe.foodNeedCount2) // ���������� >= �� ������, ���� ������ ������� ����������
                        {
                            isReady = true;
                            Debug.Log("���������� �����������! ������.");
                            break; // ������� �� ����������� �����, ���� ��� ���������� �����������
                        }
                    }
                }
            }
        }
        if (recipe.countComponent == 3)
        {
            print("��� ������� ��� �����������!!!!!!!!!!!!!!!" + recipe.countComponent);
            for (int i = 0; i < inventory.slots.Count; i++)
            {
                for (int j = 0; j < recipe.foodComponents1.Length; j++)
                {
                    if (inventory.slots[i].item == recipe.foodComponents1[j])
                    {
                        slotsForNull.Add(inventory.slots[i]);
                        readyCount1++;
                        Debug.Log($"������ ���������: {inventory.slots[i].item}. ������� �������: {readyCount1}");
                        if (readyCount1 >= recipe.foodNeedCount1) // ���������� >= �� ������, ���� ������ ������� ����������
                        {
                            isReady = true;
                            Debug.Log("���������� �����������! ������.");
                            break; // ������� �� ����������� �����, ���� ��� ���������� �����������
                        }
                    }
                }
            }
            for (int i = 0; i < inventory.slots.Count; i++)
            {
                for (int j = 0; j < recipe.foodComponents2.Length; j++)
                {
                    if (inventory.slots[i].item == recipe.foodComponents2[j])
                    {
                        slotsForNull.Add(inventory.slots[i]);
                        readyCount2++;
                        Debug.Log($"������ ���������: {inventory.slots[i].item}. ������� �������: {readyCount2}");
                        if (readyCount1 >= recipe.foodNeedCount2) // ���������� >= �� ������, ���� ������ ������� ����������
                        {
                            isReady = true;
                            Debug.Log("���������� �����������! ������.");
                            break; // ������� �� ����������� �����, ���� ��� ���������� �����������
                        }
                    }
                }
            }
            for (int i = 0; i < inventory.slots.Count; i++)
            {
                for (int j = 0; j < recipe.foodComponents3.Length; j++)
                {
                    if (inventory.slots[i].item == recipe.foodComponents3[j])
                    {
                        slotsForNull.Add(inventory.slots[i]);
                        readyCount3++;
                        Debug.Log($"������ ���������: {inventory.slots[i].item}. ������� �������: {readyCount3}");
                        if (readyCount1 >= recipe.foodNeedCount3) // ���������� >= �� ������, ���� ������ ������� ����������
                        {
                            isReady = true;
                            Debug.Log("���������� �����������! ������.");
                            break; // ������� �� ����������� �����, ���� ��� ���������� �����������
                        }
                    }
                }
            }
        }
        else
        {
            Debug.Log("���������� ����������� �� ����� 1.");
        }

        }
        public void CheckRecipe()
        {
        if(isReady)
        {
            GameObject1.SetActive(true);
        }
        else
        {
            GameObject1.SetActive(false);
        }
    }
    public void CookButton()
    {
        if (CanCraft(recipe)) // �������� �������� �� ����������� ������
        {
            AddItem(recipe.resultCook, recipe.foodCountCooked);
            RemoveItem();
        }
    }
    public void AddItem(ItemScriptableObject item, int amount)
    {
        // �������� �� ������������� �������� � ���������
        foreach (InventorySlot slot in inventory.slots)
        {
            Debug.Log("�������� �����: " + (slot.item != null ? slot.item.name : "null") + " �� ��������� � " + item.name);
            if (slot.item == item)
            {
                slot.amount += amount; // ����������� ����������
                return; // ������� ��� ��������
            }
        }

        // ���� �������� ���, ���� ������ ����
        foreach (InventorySlot slot in inventory.slots)
        {
            Debug.Log("�������� �� ������� �����: " + slot.isEmpty);
            if (slot.isEmpty) // ���� ���� ������
            {
                if (item.itemSprite == null)
                {
                    return;
                }
                slot.gameObject.GetComponent<Image>().sprite = item.itemSprite;
                slot.item = item; // ��������� �������
                slot.amount = recipe.foodCountCooked; // ������������� ����������

                Debug.Log("������� � ������: " + item.name);
                return; // ������� �������� �������
            }
            else
            {
                Debug.Log("���� �� ������: " + slot.item.name);
            }
        }

    }
    private void RemoveItem()
    {
        Debug.Log("�������� ������� ���������.");

        // ������ ��� �������� �����������, ������� ����� �������
        List<ItemScriptableObject> componentsToRemove = new List<ItemScriptableObject>();

        // ��������� ��� ���������� �� ������� � ������
        if (recipe.foodComponents1 != null)
        {
            componentsToRemove.AddRange(recipe.foodComponents1);
        }

        if (recipe.foodComponents2 != null)
        {
            componentsToRemove.AddRange(recipe.foodComponents2);
        }

        if (recipe.foodComponents3 != null)
        {
            componentsToRemove.AddRange(recipe.foodComponents3);
        }

        // ���������� ���������� � ������� �� �� ���������
        foreach (var component in componentsToRemove)
        {
            bool itemRemoved = false;

            foreach (var slot in slotsForNull)
            {

                if (slot != null && slot.item == component) // ���������, ��������� �� ������� � ����� � �����������
                {
                    if (slot.amount <= 1)
                    {
                        slot.ClearSprite();
                        itemRemoved = true;
                    }
                    else if (slot.amount > 1)
                    {
                        slot.amount--;
                        itemRemoved = true;
                    }

                    break; // ��������� ���� ����� �������� ��� ���������� ����������
                }
            }

            if (!itemRemoved)
            {
                Debug.Log($"�� ������� ������� {component.name} �� ���������.");
            }
        }

        // ������� ������ �����
        slotsForNull.RemoveAll(slot => slot == null || slot.amount <= 0);

        Debug.Log("������� ��������� ���������.");
    }
    public bool CanCraft(RecipeScriptableObject recipe)
    {
        if (recipe == null || components == null || components.Length == 0)
        {
            Debug.LogError("Recipe or its components are not initialized.");
            return false;
        }

        // ������ �������� �����������
        foreach (var component in components)
        {
            if (component == null)
            {
                Debug.LogError("One of the components is null.");
                return false;
            }

            // ����� �������� ���� ������ ��� �������� ������� ����������� � ���������
        }

        return true; // ���� ��� �������� ��������
    }

    private bool CheckComponent(ItemScriptableObject[] components, int requiredCount)
    {
        if (components.Length == 0 || requiredCount <= 0)
            return true; // ���� ����������� ��� ��� ���������� �� ���������, ���������� true

        int totalCount = 0;
        foreach (var component in components)
        {
            totalCount += GetItemCount(component);
        }

        return totalCount >= requiredCount; // ���������, ���������� �� �����������
    }

    private int GetItemCount(ItemScriptableObject item)
    {
        // ��������������, ��� � ��� ���� ������ ���������
        int count = 0;

        foreach (var inventoryItem in slots) // inventory - ��� ������ ���������
        {
            if (inventoryItem.item == item) // ��������������, ��� � �������� ���� ���� item
            {
                count += inventoryItem.amount; // ��������������, ��� � �������� ���� ���� amount
            }
        }

        return count;
    }
}
