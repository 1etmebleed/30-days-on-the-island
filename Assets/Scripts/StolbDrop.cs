using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StolbDrop : MonoBehaviour
{
    public ItemTree ItemTree;

    public GameObject stolbGO;
    public float timer; //время удаления столба
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(ItemTree.isDropped == true) 
        {
            StartCoroutine(DeleteStolb(timer));
        }
    }
    public IEnumerator DeleteStolb(float Time)
    {
        yield return new WaitForSeconds(Time);
        Destroy(stolbGO.gameObject);
    }

}
