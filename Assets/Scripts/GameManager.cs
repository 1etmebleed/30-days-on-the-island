using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Texture2D cursorTexture; 
    public Vector2 hotSpot = Vector2.zero;

    public GameObject panelCook;

    public GameObject[] recipePanels; //панели рецептов для отображения
    void Start()
    {
        AudioManager.instance.Play("soundtrack");
        // Устанавливаем курсор при старте игры
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
    }

    void Update()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
    }

    public IEnumerator CheckAllRecipesCoroutine()
    {
        foreach (var panel in recipePanels)
        {
            CookSlot cookSlot = panel.GetComponent<CookSlot>();
            if (cookSlot != null)
            {
                // Вызов метода FindFoodComponents() из CookSlot
                cookSlot.FindFoodComponents();
                cookSlot.CheckRecipe();
            }
            yield return new WaitForSeconds(0.5f); // небольшая задержка между проверками
        }
    }
}

