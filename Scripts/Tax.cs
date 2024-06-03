using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tax : MonoBehaviour
{
    [SerializeField] private Wallet wal;//кашелек

    private int employee = 0;//кол-во сотрудников
    [SerializeField] private int machineCost = 30;//цена аренды транспорта
    [SerializeField] private int rentAHouse = 200;//цена аренды помещения
    private int employeeLevel = 1;//ур сотрудников и оборудования 
    private int machineLevel = 1;

    public void newEmployee()
    {
        employee++;
    }//найм сотрудника

    public void levelUpEmployee()
    {
        employeeLevel++;
    }//лвл ап сотрудников

    public void levelUpMachine()
    {
        machineLevel++;
    }//лвл ап станков

    public void UpdateExpenses()
    {
        int totalSalary = (employeeLevel * employee * 50) + machineCost + (machineLevel * 10) + rentAHouse;
        bool bancrot = wal.SpendCoins(totalSalary);

        if (bancrot)
        {
            //вы банкрот
        }

    }// налоги


}
