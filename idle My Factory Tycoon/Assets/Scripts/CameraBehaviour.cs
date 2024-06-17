using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Masalkin632(2024-05-16): �������������� �������� ������ � ������� � ��������� [CameraTarget]

public class MainCameraBehaviour : MonoBehaviour
{
    private readonly Vector3 _cameraOffsetRelativeTarget = new Vector3(-25f, 60f, -25f);            //��������� ������ ������������ ������� [CameraTarget]
    private readonly float ScrollSpeed = 10.0f;                                                     //�������� ������ (��������� ��������)
    private Transform _target;                                                                      //������, ������������ �������� ����� ������������� ������
    private Camera _camera;                                                                         //������, � ������� ����� ����������� Zoom

    private void Start()
    {
        _target = GameObject.Find("CameraTarget").transform;                                        //����� ������� [CameraTarget]
        transform.position = _target.TransformPoint(_cameraOffsetRelativeTarget);                   //��������� ������ � ������� �������� �� ������� [CameraTarget]
        transform.LookAt(_target);
        _camera = Camera.main;                                                                      //�� ��������� ���� �������� ������ �����
    }

    private void LateUpdate()
    {
        transform.position = _target.TransformPoint(_cameraOffsetRelativeTarget);                  //��������� ������ � ������� �������� �� ������� [CameraTarget]
        transform.LookAt(_target);                                                                 //������� ������ �� ������

        //Masalkin632(2024-06-01): ������ ��������������� ������, � ����������� �� � �������� (����� ��� ������), �������� ��� ��������:
        if (_camera.orthographic)
        {
            _camera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed;
        }
        else
        {
            _camera.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed;
        }
    }

    private void Update()
    {
        transform.position = _target.TransformPoint(_cameraOffsetRelativeTarget);                  //��������� ������ � ������� �������� �� ������� [CameraTarget]
        transform.LookAt(_target);                                                                 //������� ������ �� ������

        //Masalkin632(2024-06-01): ������ ��������������� ������, � ����������� �� � �������� (����� ��� ������), �������� ��� ��������:
        if (_camera.orthographic)
        {
            _camera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed;
        }
        else
        {
            _camera.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed;
        }
    }
}