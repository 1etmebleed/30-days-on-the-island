using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class StolbDrop : MonoBehaviour
{
    public ItemTree ItemTree;

    public GameObject stolbGO;

    public GameObject logPrefab;
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
        GameObject newLog = Instantiate(logPrefab, transform.position, transform.rotation);
        Destroy(stolbGO.gameObject);
        
    }

}
