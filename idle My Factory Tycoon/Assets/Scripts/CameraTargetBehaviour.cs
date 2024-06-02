using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Masalkin632(2024-05-16): �������������� ����������� ������� ������������ �� ������� ������ � ��������� ��������� ���� �� ������

public class CameraTargetBehaviour : MonoBehaviour
{
    [SerializeField]                                //����� �������� �������� ����������� ������ � ����������
    private float _moveSpeed = 2.0f;                //�������� ����������� ������

    private Vector3 _forward;                       //������, ������������ ����� �� ������
    private Vector3 _right;                         //������, ������������ � ������ ������� ������

    //Masalkin632(2024-06-02): �������, ����������������� ����������� �������----------------------
    private float _upperBorder = 75;         //�������
    private float _lowerBorder = -75;         //������
    private float _leftBorder = -75;          //�����
    private float _rightBorder = 75;         //������
    //---------------------------------------------------------------------------------------------

    private void Start()
    {
        //������������� ������ �����
        _forward = Camera.main.transform.forward;
        _forward.y = 0;
        _forward = Vector3.Normalize(_forward);

        //������������� ������ ������
        _right = Quaternion.Euler(new Vector3(0, 90, 0)) * _forward;

        //NOTE: ����� ������������� ���������� ���, ���� ��� ��������� ������ ��������� ���������� ����
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.anyKey)
        {
            KeyboardMove();
            return;
        }

        MouseMove();
    }

    private void KeyboardMove()
    {
        Vector3 horizontalMovement = _right * _moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");        //� ���� ������ ����� ���������� ������ �� ������� ��� ����������� ����������� � ����������� � � ��������
        Vector3 verticalMovement = _forward * _moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");          //� ���� ������ ����� ���������� ������ �� ������� ��� ����������� ����������� � ����������� � � ��������

        transform.position += horizontalMovement + verticalMovement;                                            //���������� ����� ���������
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, _leftBorder, _rightBorder),
                                         transform.position.y + horizontalMovement.y + verticalMovement.y,
                                         Mathf.Clamp(transform.position.z, _lowerBorder, _upperBorder));
        
    }

    private void MouseMove()
    {
        float deltaX = 30;                      //���������� ������� ���� �� �����/������ ������ ������, �� �������� ����������� ����� ������
        float deltaY = 20;                      //���������� ������� ���� �� �������/������ ������ ������, �� �������� ����������� ����� ������

        //� ��������� ������� �������� ��������� �� ��������� ���� ������ � �������� ������ � ��� ������������� ������� ���----------------------
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
