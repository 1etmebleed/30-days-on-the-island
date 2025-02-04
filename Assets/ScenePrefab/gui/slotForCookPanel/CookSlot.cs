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

    private List<InventorySlot> slots; // Пример использования List

    public ItemScriptableObject[] components; //сделать так чтобы удалялись не все


    [Header("не трогать")]
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
        readyCount1 = 0; // Сброс перед началом
        isReady = false; // Сброс перед началом

        if (recipe.countComponent == 1)
        {
            print("ВОТ СТОЛЬКО ТУТ КОМПОНЕНТОВ!!!!!!!!!!!!!!!" + recipe.countComponent);
            for (int i = 0; i < inventory.slots.Count; i++)
            {
                for (int j = 0; j < recipe.foodComponents1.Length; j++)
                {
                    if (inventory.slots[i].item == recipe.foodComponents1[j])
                    {
                        slotsForNull.Add(inventory.slots[i]);
                        readyCount1++;
                        Debug.Log($"Найден компонент: {inventory.slots[i].item}. Текущий счетчик: {readyCount1}");
                        if (readyCount1 >= recipe.foodNeedCount1) // Используем >= на случай, если больше нужного количества
                        {
                            isReady = true;
                            Debug.Log("Достаточно компонентов! Готово.");
                            break; // Выходим из внутреннего цикла, если уже достаточно компонентов
                        }
                    }
                }
                if (isReady) break; // Выходим из внешнего цикла, если уже достаточно компонентов
            }
        }
        if (recipe.countComponent == 2)
        {
            print("ВОТ СТОЛЬКО ТУТ КОМПОНЕНТОВ!!!!!!!!!!!!!!!" + recipe.countComponent);
            for (int i = 0; i < inventory.slots.Count; i++)
            {
                for (int j = 0; j < recipe.foodComponents1.Length; j++)
                {
                    if (inventory.slots[i].item == recipe.foodComponents1[j])
                    {
                        slotsForNull.Add(inventory.slots[i]);
                        readyCount1++;
                        Debug.Log($"Найден компонент: {inventory.slots[i].item}. Текущий счетчик: {readyCount1}");
                        if (readyCount1 >= recipe.foodNeedCount1) // Используем >= на случай, если больше нужного количества
                        {
                            isReady = true;
                            Debug.Log("Достаточно компонентов! Готово.");
                            break; // Выходим из внутреннего цикла, если уже достаточно компонентов
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
                        Debug.Log($"Найден компонент: {inventory.slots[i].item}. Текущий счетчик: {readyCount2}");
                        if (readyCount1 >= recipe.foodNeedCount2) // Используем >= на случай, если больше нужного количества
                        {
                            isReady = true;
                            Debug.Log("Достаточно компонентов! Готово.");
                            break; // Выходим из внутреннего цикла, если уже достаточно компонентов
                        }
                    }
                }
            }
        }
        if (recipe.countComponent == 3)
        {
            print("ВОТ СТОЛЬКО ТУТ КОМПОНЕНТОВ!!!!!!!!!!!!!!!" + recipe.countComponent);
            for (int i = 0; i < inventory.slots.Count; i++)
            {
                for (int j = 0; j < recipe.foodComponents1.Length; j++)
                {
                    if (inventory.slots[i].item == recipe.foodComponents1[j])
                    {
                        slotsForNull.Add(inventory.slots[i]);
                        readyCount1++;
                        Debug.Log($"Найден компонент: {inventory.slots[i].item}. Текущий счетчик: {readyCount1}");
                        if (readyCount1 >= recipe.foodNeedCount1) // Используем >= на случай, если больше нужного количества
                        {
                            isReady = true;
                            Debug.Log("Достаточно компонентов! Готово.");
                            break; // Выходим из внутреннего цикла, если уже достаточно компонентов
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
                        Debug.Log($"Найден компонент: {inventory.slots[i].item}. Текущий счетчик: {readyCount2}");
                        if (readyCount1 >= recipe.foodNeedCount2) // Используем >= на случай, если больше нужного количества
                        {
                            isReady = true;
                            Debug.Log("Достаточно компонентов! Готово.");
                            break; // Выходим из внутреннего цикла, если уже достаточно компонентов
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
                        Debug.Log($"Найден компонент: {inventory.slots[i].item}. Текущий счетчик: {readyCount3}");
                        if (readyCount1 >= recipe.foodNeedCount3) // Используем >= на случай, если больше нужного количества
                        {
                            isReady = true;
                            Debug.Log("Достаточно компонентов! Готово.");
                            break; // Выходим из внутреннего цикла, если уже достаточно компонентов
                        }
                    }
                }
            }
        }
        else
        {
            Debug.Log("Количество компонентов не равно 1.");
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
        if (CanCraft(recipe)) // Добавьте проверку на возможность крафта
        {
            AddItem(recipe.resultCook, recipe.foodCountCooked);
            RemoveItem();
        }
    }
    public void AddItem(ItemScriptableObject item, int amount)
    {
        // Проверка на существование предмета в инвентаре
        foreach (InventorySlot slot in inventory.slots)
        {
            Debug.Log("Проверка слота: " + (slot.item != null ? slot.item.name : "null") + " на равенство с " + item.name);
            if (slot.item == item)
            {
                slot.amount += amount; // Увеличиваем количество
                return; // Предмет уже добавлен
            }
        }

        // Если предмета нет, ищем пустой слот
        foreach (InventorySlot slot in inventory.slots)
        {
            Debug.Log("Проверка на пустоту слота: " + slot.isEmpty);
            if (slot.isEmpty) // Если слот пустой
            {
                if (item.itemSprite == null)
                {
                    return;
                }
                slot.gameObject.GetComponent<Image>().sprite = item.itemSprite;
                slot.item = item; // Добавляем предмет
                slot.amount = recipe.foodCountCooked; // Устанавливаем количество

                Debug.Log("Добавил в ячейку: " + item.name);
                return; // Успешно добавили предмет
            }
            else
            {
                Debug.Log("Слот не пустой: " + slot.item.name);
            }
        }

    }
    private void RemoveItem()
    {
        Debug.Log("Начинаем очистку инвентаря.");

        // Список для хранения компонентов, которые нужно удалить
        List<ItemScriptableObject> componentsToRemove = new List<ItemScriptableObject>();

        // Добавляем все компоненты из рецепта в список
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

        // Перебираем компоненты и удаляем их из инвентаря
        foreach (var component in componentsToRemove)
        {
            bool itemRemoved = false;

            foreach (var slot in slotsForNull)
            {

                if (slot != null && slot.item == component) // Проверяем, совпадает ли предмет в слоте с компонентом
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

                    break; // Прерываем цикл после удаления или уменьшения количества
                }
            }

            if (!itemRemoved)
            {
                Debug.Log($"Не удалось удалить {component.name} из инвентаря.");
            }
        }

        // Удаляем пустые слоты
        slotsForNull.RemoveAll(slot => slot == null || slot.amount <= 0);

        Debug.Log("Очистка инвентаря завершена.");
    }
    public bool CanCraft(RecipeScriptableObject recipe)
    {
        if (recipe == null || components == null || components.Length == 0)
        {
            Debug.LogError("Recipe or its components are not initialized.");
            return false;
        }

        // Пример проверки компонентов
        foreach (var component in components)
        {
            if (component == null)
            {
                Debug.LogError("One of the components is null.");
                return false;
            }

            // Здесь добавьте вашу логику для проверки наличия компонентов в инвентаре
        }

        return true; // Если все проверки пройдены
    }

    private bool CheckComponent(ItemScriptableObject[] components, int requiredCount)
    {
        if (components.Length == 0 || requiredCount <= 0)
            return true; // Если компонентов нет или количество не требуется, возвращаем true

        int totalCount = 0;
        foreach (var component in components)
        {
            totalCount += GetItemCount(component);
        }

        return totalCount >= requiredCount; // Проверяем, достаточно ли компонентов
    }

    private int GetItemCount(ItemScriptableObject item)
    {
        // Предполагается, что у вас есть список инвентаря
        int count = 0;

        foreach (var inventoryItem in slots) // inventory - ваш список предметов
        {
            if (inventoryItem.item == item) // Предполагается, что у предмета есть поле item
            {
                count += inventoryItem.amount; // Предполагается, что у предмета есть поле amount
            }
        }

        return count;
    }
}
