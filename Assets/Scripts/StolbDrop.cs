using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StolbDrop : MonoBehaviour
{
    public ItemTree ItemTree;

    public GameObject stolbGO;

    public GameObject logPrefab;
    public float timer; // время удаления столба
    public float pushForce = 5f; // сила толчка

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ItemTree.isDropped == true)
        {

            // Получаем компонент Rigidbody у stolbGO
            Rigidbody stolbRigidbody = stolbGO.GetComponent<Rigidbody>();

            if (stolbRigidbody != null)
            {
                // Применяем силу в сторону (например, вектора вперед от ствола)
                Vector3 pushDirection = transform.right; // Направление вперед от ствола
                stolbRigidbody.AddForce(pushDirection * pushForce, ForceMode.Impulse);
            }

            StartCoroutine(DeleteStolb(timer));
        }
    }

    public IEnumerator DeleteStolb(float Time)
    {
        yield return new WaitForSeconds(Time);


        // Создаем новый объект logPrefab
        Instantiate(logPrefab, transform.position, transform.rotation);

        // Удаляем старый столб
        Destroy(stolbGO.gameObject);
    }
}
