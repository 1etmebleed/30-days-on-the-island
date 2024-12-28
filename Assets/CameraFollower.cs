using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] public Transform target; //������� ������
    [SerializeField] public Vector3 offset; //������� ������ �� �������
    [SerializeField] private float cameraSpeed = 1f; //�������� ������
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cameraMove();
    }
    public void cameraMove()
    {
        var nextPosition = Vector3.Lerp(transform.position,target.transform.position + offset,Time.fixedDeltaTime * cameraSpeed);

        transform.position = nextPosition;
    }



}
