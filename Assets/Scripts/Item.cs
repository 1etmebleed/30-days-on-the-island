using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [Header("��������� ��������, ����������� ������ ���� � ����� item!")]
    [Header("")]

    [Header("������ �� �������")]
    public ItemScriptableObject item; //�������

    [Header("���������� ����������� ��������� �� �������")]
    public int amount; // ������� ���-�� ��������� �� ���������

    [Header("��� ������������ �����!")]

    [Header("����������� ���� ��� ������ ������� ���� ��� �� ����!")]
    public GameObject itemGO; //������ ����

    [Header("������ ���� ���� ��� ����������� ���� (���� �������)")]
    public GameObject nullBushGO; // ������ (���������) ����


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

    public bool isOutlined;
    public Outline outline; // ������ �� ��������� Outline

    public void Start()
    {
        outline = GetComponent<Outline>(); // �������� ��������� Outline
        if (outline != null)
        {
            outline.enabled = false; // ������� ��������� ���������
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