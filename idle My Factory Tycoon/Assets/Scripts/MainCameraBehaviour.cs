using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Masalkin632(2024-05-16): осуществляется привязка камеры к объекту с названием [CameraTarget]

public class MainCameraBehaviour : MonoBehaviour
{
    private readonly Vector3 _cameraOffsetRelativeTarget = new Vector3(-25f, 60f, -25f);            //положение камеры относительно объекта [CameraTarget]
    private readonly float _scrollSpeed = 10.0f;                                                    //скорость скрола (изменения масштаба)
    private Transform _target;                                                                      //объект, относительно которого будет располагаться камера
    private Camera _camera;                                                                         //камера, с которой будем настраивать Zoom

    //Masalkin632(2024-06-27): добавим два поля для задания диапозона изменения приближения камеры
    [SerializeField] private float _minOrthographicSize = 7f;                                       //минимальный размер области просмотра камеры
    [SerializeField] private float _maxOrthographicSize = 25f;                                       //максимальный размер области просмотра камеры
    [SerializeField] private float _touchZoomSpeed = 0.1f;

    //Masalkin632(2024-07-06): в следующих переменных храним прикосновения
    Touch _touch1, _touch2;

    private void Start()
    {
        _target = GameObject.Find("CameraTarget").transform;                                        //поиск объекта [CameraTarget]
        transform.position = _target.TransformPoint(_cameraOffsetRelativeTarget);                   //установка камеры с заданым смещение от объекта [CameraTarget]
        transform.LookAt(_target);
        _camera = Camera.main;                                                                      //по умолчанию берём основную камеру сцены
    }

    //Masalkin632(2024-07-06): в методе Update будем реализовывать зум камеры через сенсорный экран мобильных устройств
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
        transform.position = _target.TransformPoint(_cameraOffsetRelativeTarget);                  //установка камеры с заданым смещение от объекта [CameraTarget]
        transform.LookAt(_target);                                                                 //доворот камеры на объект

        //Masalkin632(2024-06-01): делаем масштабирование камеры, в зависимости от её проекции (конус или призма), возможно два варианта:
        if (_camera.orthographic)
        {
            //Masalkin632(2024-06-27): при изменении размера камеры через метод Mathf.Clamp убеждаемся, что диапазон останет в требуемых пределах

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