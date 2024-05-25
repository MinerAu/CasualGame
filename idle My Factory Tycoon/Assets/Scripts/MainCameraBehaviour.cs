using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Masalkin632(2024-05-16): осуществляется привязка камеры к объекту с названием [CameraTarget]

public class MainCameraBehaviour : MonoBehaviour
{
    private readonly Vector3 _cameraOffsetRelativeTarget = new Vector3(-25f, 45f, -25f);            //положение камеры относительно объекта [CameraTarget]
    private Transform _target;                                                                      //объект, относительно которого будет располагаться камера

    private void Start()
    {
        _target = GameObject.Find("CameraTarget").transform;                                        //поиск объекта [CameraTarget]
        transform.position = _target.TransformPoint(_cameraOffsetRelativeTarget);                   //установка камеры с заданым смещение от объекта [CameraTarget]
    }

    private void LateUpdate()
    {
        transform.position = _target.TransformPoint(_cameraOffsetRelativeTarget);                  //установка камеры с заданым смещение от объекта [CameraTarget]
        transform.LookAt(_target);                                                                 //доворот камеры на объект
    }
}