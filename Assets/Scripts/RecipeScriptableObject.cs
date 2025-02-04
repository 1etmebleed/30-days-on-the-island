using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "recipe", menuName = "Inventory/recipe/New recipe")]

public class RecipeScriptableObject : ScriptableObject
{

    public string profession; //профессия необходимая для крафта, если необходимо
    public string skull; //скилл необходимый для крафта, если необходимо

    [Range(1, 3)] // Ограничиваем значение от 1 до 3
    [SerializeField] public int countComponent;

    public ItemScriptableObject[] foodComponents1; //компоненты блюда 1
    [Range(1, 99)] // Ограничиваем значение от 1 до 3
    public int foodNeedCount1;

    public ItemScriptableObject[] foodComponents2; //компоненты блюда 2
    [Range(1, 99)] // Ограничиваем значение от 1 до 3
    public int foodNeedCount2;

    public ItemScriptableObject[] foodComponents3; //компоненты блюда 3
    [Range(1, 99)] // Ограничиваем значение от 1 до 3
    public int foodNeedCount3;

    public ItemScriptableObject resultCook; //готовое блюдо



    public int foodCountCooked; //сколько штук приготовится 

    public Sprite sprite; //иконка 

    public Sprite[] spritesTags; //спрайты для компонентов блюда

    public string description; //описание блюда

    public string title; //название блюда

    public string[] buffTags; //список баффов блюда

    public int hungry; //Сумма восполнения голода

    public int health; //сумма восполнения здоровья
}
