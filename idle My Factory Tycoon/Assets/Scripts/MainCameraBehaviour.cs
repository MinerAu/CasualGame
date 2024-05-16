using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Masalkin632(2024-05-16): �������������� �������� ������ � ������� � ��������� [CameraTarget]

public class MainCameraBehaviour : MonoBehaviour
{
    private readonly Vector3 _cameraOffsetRelativeTarget = new Vector3(-25f, 45f, -25f);            //��������� ������ ������������ ������� [CameraTarget]
    private Transform _target;                                                                      //������, ������������ �������� ����� ������������� ������

    private void Start()
    {
        _target = GameObject.Find("CameraTarget").transform;                                        //����� ������� [CameraTarget]
        transform.position = _target.TransformPoint(_cameraOffsetRelativeTarget);                   //��������� ������ � ������� �������� �� ������� [CameraTarget]
    }

    private void LateUpdate()
    {
        transform.position = _target.TransformPoint(_cameraOffsetRelativeTarget);                  //��������� ������ � ������� �������� �� ������� [CameraTarget]
        transform.LookAt(_target);                                                                 //������� ������ �� ������
    }
}