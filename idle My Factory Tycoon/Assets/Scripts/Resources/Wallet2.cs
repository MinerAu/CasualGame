using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;
using YG;

public class Wallet2 : MonoBehaviour
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

    public void SetCoins(int amount)
    {
        coins = amount;
    }

    [ContextMenu("Добавить 3000$")]
    private void Add3000Coins()
    {
        AddCoins(3000);
    }
}
