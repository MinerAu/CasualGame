using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Masalkin632(2024-05-16): осуществляется перемещение объекта взависимости от нажатых клавиш и положения указателя мыши на экране

public class CameraTargetBehaviour2 : MonoBehaviour
{
    [SerializeField]                                //можем изменить скорость перемещения камеры в инспекторе
    private float _moveSpeed = 2.0f;                //скорость перемещения камеры

    private Vector3 _forward;                       //вектор, направленный вдаль от игрока
    private Vector3 _right;                         //вектор, направленный в правую сторону экрана

    //Masalkin632(2024-06-02): границы, ограничивыввающие перемещение объекта----------------------
    [SerializeField] private float _upperBorder = 180;         //верхняя
    [SerializeField] private float _lowerBorder = -120;         //нижняя
    [SerializeField] private float _leftBorder = 70;          //левая
    [SerializeField] private float _rightBorder = 410;         //правая
    //---------------------------------------------------------------------------------------------

    private void Start()
    {
        //устанавливаем вектор вперёд
        _forward = Camera.main.transform.forward;
        _forward.y = 0;
        _forward = Vector3.Normalize(_forward);

        //устанавливаем вектор вправо
        _right = Quaternion.Euler(new Vector3(0, 90, 0)) * _forward;

        //NOTE: может потребоваться переписать код, если при отрисовки уровня изменится ориентация осей
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.anyKey)
        {
            KeyboardMove();
            return;
        }

        //MouseMove();
    }

    private void KeyboardMove()
    {
        Vector3 horizontalMovement = _right * _moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");        //в этой строке сразу определяем нажата ли клавиша для поперечного перемещения и преобразуем её в смещение
        Vector3 verticalMovement = _forward * _moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");          //в этой строке сразу определяем нажата ли клавиша для продольного перемещения и преобразуем её в смещение

        Vector3 newPosition = transform.position + horizontalMovement + verticalMovement;                                          //определяем новое положение
        /*Vector3 correctedPosition = new Vector3(Mathf.Clamp(newPosition.x, _leftBorder, _rightBorder),
                                                newPosition.y,
                                                Mathf.Clamp(newPosition.z, _lowerBorder, _upperBorder));*/

        if (newPosition.x < _leftBorder)
        {
            newPosition.x = _leftBorder;
        }
        if (newPosition.x > _rightBorder)
        {
            newPosition.x = _rightBorder;
        }
        if (newPosition.z < _lowerBorder)
        {
            newPosition.z = _lowerBorder;
        }
        if (newPosition.z > _upperBorder)
        {
            newPosition.z = _upperBorder;
        }


        transform.position = newPosition;
    }

    private void MouseMove()
    {
        float deltaX = 30;                      //расстояние курсора мыши до левой/правой границ экрана, на которогм срабатывает сдвиг экрана
        float deltaY = 20;                      //расстояние курсора мыши до верхней/нижней границ экрана, на которогм срабатывает сдвиг экрана

        //в следующих строках проверям находится ли указатель мыши близко к границам экрана и при необходимости смещаем его----------------------
        if (Input.mousePosition.x < deltaX)
        {
            Vector3 leftMovement = -_right * _moveSpeed * Time.deltaTime;
            transform.position += leftMovement;
        }

        if (Input.mousePosition.x > Screen.width - deltaX)
        {
            Vector3 rightMovement = _right * _moveSpeed * Time.deltaTime;
            transform.position += rightMovement;
        }

        if (Input.mousePosition.y > Screen.height - deltaY)
        {
            Vector3 upMovement = _forward * _moveSpeed * Time.deltaTime;
            transform.position += upMovement;
        }

        if (Input.mousePosition.y < deltaY)
        {
            Vector3 downMovement = -_forward * _moveSpeed * Time.deltaTime;
            transform.position += downMovement;
        }
        //---------------------------------------------------------------------------------------------------------------------------------------
    }
}
