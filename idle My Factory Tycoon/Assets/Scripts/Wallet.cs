using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int coins = 0;

    public void AddCoins(int amount)
    {
        coins += amount;
    }//���������� ����� ���������� ��������

    public bool SpendCoins(int amount)
    {

        if (coins >= amount)
        {
            coins -= amount;
            return true;
        }
        else
        {
            return false;
        }

    }//������ ������ �� ��������

    public int GetCoins()
    {
        return coins;
    }//�������� ������� �������� ����� � ��������

}
