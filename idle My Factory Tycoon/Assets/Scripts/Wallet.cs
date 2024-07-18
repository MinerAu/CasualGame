using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int coins = 0;

    public void AddCoins(int amount)
    {
        coins += amount;
    }//вызываемый метод пополнения кошелька

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

    }//тратим монеты из кошелька

    public int GetCoins()
    {
        return coins;
    }//получить текущее значение монет в кошельке

}
