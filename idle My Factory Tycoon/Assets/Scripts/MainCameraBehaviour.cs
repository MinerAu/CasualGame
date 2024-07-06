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

    //Masalkin632(2024-06-27): ������� ��� ���� ��� ������� ��������� ��������� ����������� ������
    [SerializeField] private float _minOrthographicSize = 7f;                                       //����������� ������ ������� ��������� ������
    [SerializeField] private float _maxOrthographicSize = 25f;                                       //������������ ������ ������� ��������� ������
    [SerializeField] private float _touchZoomSpeed = 0.1f;

    //Masalkin632(2024-07-06): � ��������� ���������� ������ �������������
    Touch _touch1, _touch2;

    private void Start()
    {
        _target = GameObject.Find("CameraTarget").transform;                                        //����� ������� [CameraTarget]
        transform.position = _target.TransformPoint(_cameraOffsetRelativeTarget);                   //��������� ������ � ������� �������� �� ������� [CameraTarget]
        transform.LookAt(_target);
        _camera = Camera.main;                                                                      //�� ��������� ���� �������� ������ �����
    }

    //Masalkin632(2024-07-06): � ������ Update ����� ������������� ��� ������ ����� ��������� ����� ��������� ���������
    private void Update()
    {
        if (Input.touchCount == 2)
        {
            _touch1 = Input.GetTouch(0);
            _touch2 = Input.GetTouch(1);

            Vector2 touch1DeltaPos = _touch1.position - _touch1.deltaPosition;
            Vector2 touch2DeltaPos = _touch2.position - _touch2.deltaPosition;

            float distanceDeltaTouches = (touch1DeltaPos - touch2DeltaPos).magnitude;
            float distanceTouches = (_touch1.position - _touch2.position).magnitude;
            float distance = distanceDeltaTouches - distanceTouches;

            _camera.orthographicSize = Mathf.Clamp(
                _camera.orthographicSize + distance * _touchZoomSpeed,
                _minOrthographicSize,
                _maxOrthographicSize);
        }
    }

    private void LateUpdate()
    {
        transform.position = _target.TransformPoint(_cameraOffsetRelativeTarget);                  //��������� ������ � ������� �������� �� ������� [CameraTarget]
        transform.LookAt(_target);                                                                 //������� ������ �� ������

        //Masalkin632(2024-06-01): ������ ��������������� ������, � ����������� �� � �������� (����� ��� ������), �������� ��� ��������:
        if (_camera.orthographic)
        {
            //Masalkin632(2024-06-27): ��� ��������� ������� ������ ����� ����� Mathf.Clamp ����������, ��� �������� ������� � ��������� ��������

            _camera.orthographicSize = Mathf.Clamp(
                _camera.orthographicSize - Input.GetAxis("Mouse ScrollWheel") * _scrollSpeed,
                _minOrthographicSize,
                _maxOrthographicSize);
        }
        else
        {
            _camera.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * _scrollSpeed;
        }
    }
}