using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int coins = 0;

    public event UnityAction<int> CoinsAmountChanged;

    public void AddCoins(int amount)
    {
        coins += amount;
        CoinsAmountChanged?.Invoke(coins);
    }//���������� ����� ���������� ��������

    public bool SpendCoins(int amount)
    {

        if (coins >= amount)
        {
            coins -= amount;
            CoinsAmountChanged?.Invoke(coins);
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
