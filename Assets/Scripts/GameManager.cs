using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Texture2D cursorTexture; 
    public Vector2 hotSpot = Vector2.zero;

    public GameObject panelCook;

    public GameObject[] recipePanels; //������ �������� ��� �����������
    void Start()
    {
        AudioManager.instance.Play("soundtrack");
        // ������������� ������ ��� ������ ����
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
                // ����� ������ FindFoodComponents() �� CookSlot
                cookSlot.FindFoodComponents();
                cookSlot.CheckRecipe();
            }
            yield return new WaitForSeconds(0.5f); // ��������� �������� ����� ����������
        }
    }
}

