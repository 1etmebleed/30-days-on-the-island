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

    public ParticleSystem particleSystem; // ������� ������

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
            if(hitCount <  hitNeed)
            {
                AudioManager.instance.Play("hitWood");
                hitCount++;
                particleSystem.Play();

                StartCoroutine(ShakeTree());

                if(hitCount == hitNeed)
                {
                    StartCoroutine(StolbSoundDropped());
                }
            }

            if (hitCount == 5)
            {
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

    private IEnumerator ShakeTree()
    {
        Vector3 originalPosition = Stolb.transform.position;
        float shakeDuration = 0.5f; // ����������������� ������
        float shakeMagnitude = 0.1f; // ��������� ������

        float elapsed = 0.0f;
        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-shakeMagnitude, shakeMagnitude);
            float y = Random.Range(-shakeMagnitude, shakeMagnitude);
            Stolb.transform.position = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);

            elapsed += Time.deltaTime;
            yield return null;
        }

        Stolb.transform.position = originalPosition; // ���������� �� �������� �������
    }
}