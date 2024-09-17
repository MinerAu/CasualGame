using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxCalculator : MonoBehaviour
{
    private const int WorkerTax = 40;
    private const int MachineTax = 20;

    [SerializeField] private Wallet _wallet;
    [SerializeField] private AdjacentWorkersAndMachinesIncluded _reestr;

    public void WithholdTax()
    {
        int taxValue = WorkerTax * _reestr.GetActiveWorkersCount() + 
                       MachineTax * _reestr.GetActiveMachinesCount();
        
        if (_wallet.GetCoins() >= taxValue)
        {
            _wallet.SpendCoins(taxValue);
        }
        else
        {
            _wallet.SpendCoins(_wallet.GetCoins());
        }

        Debug.Log($"Tax={taxValue}");
    }
}
