using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Masalkin632(2024-05-16): �������������� �������� ������ � ������� � ��������� [CameraTarget]

public class MainCameraBehaviour : MonoBehaviour
{
    private readonly Vector3 _cameraOffsetRelativeTarget = new Vector3(-25f, 60f, -25f);            //��������� ������ ������������ ������� [CameraTarget]
    private readonly float _scrollSpeed = 10.0f;                                                    //�������� ������ (��������� ��������)
    private Transform _target;                                                                      //������, ������������ �������� ����� ������������� ������
    private Camera _camera;                                                                         //������, � ������� ����� ����������� Zoom
   //MinerAu[Cergei](2024.09.12) �������� ������ GameObject ��� ������� ����                                                                               
    [SerializeField] private List<GameObject> _menuList;
    private bool _isMenuOpen = false; // ����, ������������� ��������� ����

    //Masalkin632(2024-06-27): ������� ��� ���� ��� ������� ��������� ��������� ����������� ������
    [SerializeField] private float _minOrthographicSize = 7f;                                       //����������� ������ ������� ��������� ������
    [SerializeField] private float _maxOrthographicSize = 25f;                                       //������������ ������ ������� ��������� ������

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

        _isMenuOpen = IsAnyMenuOpen(_menuList);

        //Masalkin632(2024-06-01): ������ ��������������� ������, � ����������� �� � �������� (����� ��� ������), �������� ��� ��������:
        //MinerAu[Cergei](2024.09.12) ��������� ������� � ����������� �� ��������� ����
        if (_camera.orthographic)
        {
            if (!_isMenuOpen)
            {
                _camera.orthographicSize = Mathf.Clamp(
                    _camera.orthographicSize - Input.GetAxis("Mouse ScrollWheel") * _scrollSpeed,
                    _minOrthographicSize,
                    _maxOrthographicSize);
            }
            else
            {
                // ��������� ���������� �������, ���� ���� �������
                _camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize, _minOrthographicSize, _maxOrthographicSize);
            }
        }
        else
        {
                _camera.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * _scrollSpeed;  
        }
    }

    //MinerAu[Cergei](2024.09.12) ����� ���������, ������� �� ���� �� ���� ���� �� ������
    private bool IsAnyMenuOpen(List<GameObject> menuList)
    {
        foreach (GameObject menu in menuList)
        {
            if (menu != null && menu.activeSelf)
            {
                return true;
            }
        }
        return false;
    }
}