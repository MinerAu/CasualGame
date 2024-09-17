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
   //MinerAu[Cergei](2024.09.12) Добавлен список GameObject для задания меню                                                                               
    [SerializeField] private List<GameObject> _menuList;
    private bool _isMenuOpen = false; // флаг, отслеживающий состояние меню

    //Masalkin632(2024-06-27): добавим два поля для задания диапозона изменения приближения камеры
    [SerializeField] private float _minOrthographicSize = 7f;                                       //минимальный размер области просмотра камеры
    [SerializeField] private float _maxOrthographicSize = 25f;                                       //максимальный размер области просмотра камеры

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

        _isMenuOpen = IsAnyMenuOpen(_menuList);

        //Masalkin632(2024-06-01): делаем масштабирование камеры, в зависимости от её проекции (конус или призма), возможно два варианта:
        //MinerAu[Cergei](2024.09.12) Управляем камерой в зависимости от состояния меню
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
                // Отключаем управление камерой, если меню открыто
                _camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize, _minOrthographicSize, _maxOrthographicSize);
            }
        }
        else
        {
                _camera.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * _scrollSpeed;  
        }
    }

    //MinerAu[Cergei](2024.09.12) Метод проверяет, открыто ли хотя бы одно меню из списка
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