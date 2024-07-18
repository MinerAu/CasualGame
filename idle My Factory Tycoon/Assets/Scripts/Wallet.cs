using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int coins = 0;

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
