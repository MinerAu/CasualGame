using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tax : MonoBehaviour
{
    [SerializeField] private Wallet wal;//�������

    private int employee = 0;//���-�� �����������
    [SerializeField] private int machineCost = 30;//���� ������ ����������
    [SerializeField] private int rentAHouse = 200;//���� ������ ���������
    private int employeeLevel = 1;//�� ����������� � ������������ 
    private int machineLevel = 1;

    public void newEmployee()
    {
        employee++;
    }//���� ����������

    public void levelUpEmployee()
    {
        employeeLevel++;
    }//��� �� �����������

    public void levelUpMachine()
    {
        machineLevel++;
    }//��� �� �������

    public void UpdateExpenses()
    {
        int totalSalary = (employeeLevel * employee * 50) + machineCost + (machineLevel * 10) + rentAHouse;
        bool bancrot = wal.SpendCoins(totalSalary);

        if (bancrot)
        {
            //�� �������
        }

    }// ������


}
