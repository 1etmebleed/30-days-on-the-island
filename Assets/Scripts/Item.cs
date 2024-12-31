using System.Collections;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("��������� ��������, ����������� ������ ���� � ����� item!")]
    [Header("")]

    [Header("������ �� �������")]
    public ItemScriptableObject item; //�������

    [Header("������ ������������ ��������")]
    public Sprite spriteItem; //������ ��������

    [Header("���������� ����������� ��������� �� �������")]
    public int amount; // ������� ���-�� ��������� �� ���������

    [Header("����������� ���� ��� ������ ������� ���� ��� �� ����!")]
    public GameObject itemGO; //������ ����

    [Header("������ ���� ���� ��� ����������� ���� (���� �������)")]
    public GameObject nullBushGO; // ������ (���������) ����

    [Header("��� ������������ �����!")]
    [Header("���� ��� ����������� ����!")]
    public bool thisIsBush; // ���������� ���� ��� ����������� ������

    [Header("����� ����� �����")]
    public float bushGrowTime;

    [Header("������� ������� �� ������ �����!")]
    public bool isGrowStart = false;
    [Header("������� ������� �� �������� �����!")]
    public bool itemReady; // ������� ����� � ����� � ���������


    [Header("�� �������!")]
    public bool isDelete = false;
    [Header("�� �������!")]
    public bool isPicked;

    private void Start()
    {
        // �������������, ���� �����
    }

    private void Update()
    {
        if (isDelete && !thisIsBush)
        {
            Destroy(this.gameObject);
        }

        if (thisIsBush && isPicked)
        {
            // ���������, ��� ����� BushGrow ���������� ������ ���� ���
            if (itemReady)
            {

                // ������� ����� ������ nullBushGO �� ����� �������� �������
                GameObject newBush = Instantiate(nullBushGO, transform.position, transform.rotation);

                // ���������� ������� ������
                Destroy(this.gameObject);

                itemReady = false; // ���������� ����, ����� �� �������� ����� �����
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