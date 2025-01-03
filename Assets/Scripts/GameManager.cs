using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Texture2D cursorTexture; 
    public Vector2 hotSpot = Vector2.zero; 
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


}
