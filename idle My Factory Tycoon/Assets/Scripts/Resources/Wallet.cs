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
    }//вызываемый метод пополнения кошелька

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

    }//тратим монеты из кошелька

    public int GetCoins()
    {
        return coins;
    }//получить текущее значение монет в кошельке

}
