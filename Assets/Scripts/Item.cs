using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public ItemScriptableObject item;
    public int amount; //—колько кол-ва предметов мы подбираем
    public GameObject itemGO;
    public Sprite spriteItem;
    public bool isDelete = false;

    public bool isPicked;

    public bool thisIsBush; //ѕеременна€ флаг дл€ неудал€емых кустов

    public GameObject nullBushGO; //ѕустой (собранный) куст
    public bool itemReady; //предмет вырос и готов к собиранию
    public bool isCorountineStart = false;

    private void Start()
    {
         
    }
    public void Update()
    {
        if (isDelete && !thisIsBush)
        {
            Destroy(this.gameObject);
        }

        if (thisIsBush && isPicked && !isCorountineStart) // ƒобавлено условие дл€ проверки isCorountineStart
        {
            BushGrow();
        }
    }

    public void BushGrow() // –ост куста
    {
        isCorountineStart = true;
        StartCoroutine(GrowingBush());
    }

    public IEnumerator GrowingBush()
    {
        Debug.Log("Ќачинаем рост куста");
        ReplaceWithNullBush();
        yield return new WaitForSeconds(5f);
        ReplaceWithFullBush();
        Debug.Log(" уст вырос");
        isPicked = false;
        isCorountineStart = false; // —брасываем флаг после завершени€ корутины
    }
    private void ReplaceWithNullBush()
    {
        print("ћќƒ≈Ћ№ ј ѕќћ≈ЌяЋј—№");
        nullBushGO = gameObject;
    }
    private void ReplaceWithFullBush()
    {
        print("ћќƒ≈Ћ№ ј ѕќћ≈ЌяЋј—№ 2");
        itemGO = gameObject;
    }

}
