using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Masalkin632(2024-05-16): осуществляется привязка камеры к объекту с названием [CameraTarget]

public class MainCameraBehaviour : MonoBehaviour
{
    private readonly Vector3 _cameraOffsetRelativeTarget = new Vector3(-25f, 60f, -25f);            //положение камеры относительно объекта [CameraTarget]
    private readonly float ScrollSpeed = 10.0f;                                                     //скорость скрола (изменения масштаба)
    private Transform _target;                                                                      //объект, относительно которого будет располагаться камера
    private Camera _camera;                                                                         //камера, с которой будем настраивать Zoom

    private void Start()
    {
        _target = GameObject.Find("CameraTarget").transform;                                        //поиск объекта [CameraTarget]
        transform.position = _target.TransformPoint(_cameraOffsetRelativeTarget);                   //установка камеры с заданым смещение от объекта [CameraTarget]
        transform.LookAt(_target);
        _camera = Camera.main;                                                                      //по умолчанию берём основную камеру сцены
    }

    private void LateUpdate()
    {
        transform.position = _target.TransformPoint(_cameraOffsetRelativeTarget);                  //установка камеры с заданым смещение от объекта [CameraTarget]
        transform.LookAt(_target);                                                                 //доворот камеры на объект

        //Masalkin632(2024-06-01): делаем масштабирование камеры, в зависимости от её проекции (конус или призма), возможно два варианта:
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
        transform.position = _target.TransformPoint(_cameraOffsetRelativeTarget);                  //установка камеры с заданым смещение от объекта [CameraTarget]
        transform.LookAt(_target);                                                                 //доворот камеры на объект

        //Masalkin632(2024-06-01): делаем масштабирование камеры, в зависимости от её проекции (конус или призма), возможно два варианта:
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