using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StolbDrop : MonoBehaviour
{
    public ItemTree ItemTree;

    public GameObject stolbGO;

    public GameObject logPrefab;
    public float timer; // ����� �������� ������
    public float pushForce = 5f; // ���� ������

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ItemTree.isDropped == true)
        {

            // �������� ��������� Rigidbody � stolbGO
            Rigidbody stolbRigidbody = stolbGO.GetComponent<Rigidbody>();

            if (stolbRigidbody != null)
            {
                // ��������� ���� � ������� (��������, ������� ������ �� ������)
                Vector3 pushDirection = transform.right; // ����������� ������ �� ������
                stolbRigidbody.AddForce(pushDirection * pushForce, ForceMode.Impulse);
            }

            StartCoroutine(DeleteStolb(timer));
        }
    }

    public IEnumerator DeleteStolb(float Time)
    {
        yield return new WaitForSeconds(Time);


        // ������� ����� ������ logPrefab
        Instantiate(logPrefab, transform.position, transform.rotation);

        // ������� ������ �����
        Destroy(stolbGO.gameObject);
    }
}
