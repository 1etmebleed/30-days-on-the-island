using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour
{
    public RecipeScriptableObject recipeScriptable;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int  i = 0;i<recipeScriptable.buffTags.Length;i++)
        {
            if (recipeScriptable.buffTags[i] == null) { } //доделать логику поиска рецепта
        }
    }
}
