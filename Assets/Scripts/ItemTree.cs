using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTree : MonoBehaviour
{
    // ������ ������, ����� ������ � ������..

    public GameObject leaves;
    public GameObject pinok;
    public GameObject Stolb;
    public GameObject log; //������ ������ ������� ����� ���������

    [SerializeField] public int hitCount = 0;
    [SerializeField] public int hitNeed = 5;

    public bool isDropped = false;


    private bool destroyReady;

    public void Start()
    {
        pinok.gameObject.SetActive(false);
        // ���������, ��� � Stolb ���� Rigidbody
        if (Stolb.GetComponent<Rigidbody>() == null)
        {
            Stolb.AddComponent<Rigidbody>();
        }
        Stolb.GetComponent<Rigidbody>().isKinematic = true; // ������ ��� �������������� �� ���������
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("������ ����� �� �������� ������: " + other.name);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("������ ����� � ������� ������: " + other.name);
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