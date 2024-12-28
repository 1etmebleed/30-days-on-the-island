using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTree : MonoBehaviour
{
    // Скрипт дерева, можно ломать и падать..

    public GameObject leaves;
    public GameObject pinok;
    public GameObject Stolb;
    public GameObject log; //префаб дерева которое можно подобрать

    [SerializeField] public int hitCount = 0;
    [SerializeField] public int hitNeed = 5;

    public bool isDropped = false;


    private bool destroyReady;

    public void Start()
    {
        pinok.gameObject.SetActive(false);
        // Убедитесь, что у Stolb есть Rigidbody
        if (Stolb.GetComponent<Rigidbody>() == null)
        {
            Stolb.AddComponent<Rigidbody>();
        }
        Stolb.GetComponent<Rigidbody>().isKinematic = true; // Делаем его кинематическим по умолчанию
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Объект вышел из триггера дерева: " + other.name);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Объект вошел в триггер дерева: " + other.name);
            destroyReady = true;
        }
    }

    public void DestroyTree()
    {
        if (Input.GetKeyDown(KeyCode.E) && destroyReady)
        {
            hitCount++;
            AudioManager.instance.Play("hitWood");
            if (hitCount == 5)
            {
                StartCoroutine(StolbSoundDropped());
                Destroy(leaves);
                pinok.gameObject.SetActive(true);
                Stolb.GetComponent<Rigidbody>().isKinematic = false;
                Stolb.transform.SetParent(null);

                isDropped = true;
            }
        }
    }

    public void Update()
    {
        DestroyTree();
    }
    public IEnumerator StolbSoundDropped()
    {
        yield return new WaitForSeconds(0f);
        AudioManager.instance.Play("treeFallingSound");
    }

}