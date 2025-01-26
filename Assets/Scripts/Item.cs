using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [Header("Настройка предмета, ОБЯЗАТЕЛЬНО ДОЛЖЕН БЫТЬ С ТЕГОМ item!")]
    [Header("")]

    [Header("Ссылка на предмет")]
    public ItemScriptableObject item; //предмет

    [Header("Количество подбираемых предметов за нажатие")]
    public int amount; // Сколько кол-ва предметов мы подбираем

    [Header("ДЛЯ ОТРАСТАЮЩЕГО КУСТА!")]

    [Header("Наполненный куст ИЛИ просто предмет если это не куст!")]
    public GameObject itemGO; //Полный куст

    [Header("пустой куст ЕСЛИ это отрастающий куст (НИЖЕ ГАЛОЧКА)")]
    public GameObject nullBushGO; // Пустой (собранный) куст


    [Header("Если это ОТРАСТАЮЩИЙ КУСТ!")]
    public bool thisIsBush; // Переменная флаг для неудаляемых кустов

    [Header("Время роста куста")]
    public float bushGrowTime;

    [Header("Ставить галочку на пустом кусте!")]
    public bool isGrowStart = false;
    [Header("Ставить галочку на вырасшем кусте!")]
    public bool itemReady; // Предмет вырос и готов к собиранию


    [Header("НЕ ТРОГАТЬ!")]
    public bool isDelete = false;
    [Header("НЕ ТРОГАТЬ!")]
    public bool isPicked;

    public bool isOutlined;
    public Outline outline; // Ссылка на компонент Outline

    public void Start()
    {
        outline = GetComponent<Outline>(); // Получаем компонент Outline
        if (outline != null)
        {
            outline.enabled = false; // Сначала отключаем подсветку
        }
    }

    private void Update()
    {
        if (isDelete && !thisIsBush)
        {
            Destroy(this.gameObject);
        }

        if (thisIsBush && isPicked)
        {
            // Убедитесь, что метод BushGrow вызывается только один раз
            if (itemReady)
            {

                // Создаем новый объект nullBushGO на месте текущего объекта
                GameObject newBush = Instantiate(nullBushGO, transform.position, transform.rotation);

                // Уничтожаем текущий объект
                Destroy(this.gameObject);

                itemReady = false; // Сбрасываем флаг, чтобы не вызывать метод снова
                isGrowStart = true;
            }
            
        }
        if (isGrowStart)
        {
            StartCoroutine(bushGoGrow());
        }
    }
    public void GrowStart()
    {

    }
    public IEnumerator bushGoGrow()
    {
        yield return new WaitForSeconds(bushGrowTime);

        Destroy(this.gameObject);

        GameObject newBush = Instantiate(itemGO, transform.position, transform.rotation);
    }
}