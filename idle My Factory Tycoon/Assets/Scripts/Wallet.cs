using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int coins = 0;

    public void AddCoins(int amount)
    {
        coins += amount;
    }//âûçûâàåìûé ìåòîä ïîïîëíåíèÿ êîøåëüêà

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

    }//òðàòèì ìîíåòû èç êîøåëüêà

    public int GetCoins()
    {
        return coins;
    }//ïîëó÷èòü òåêóùåå çíà÷åíèå ìîíåò â êîøåëüêå

}
