using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContractsManager : MonoBehaviour
{
    private int _maximumContracts = 3;
    private List<Contract> _contracts = new List<Contract>();

    public bool AddContract(Contract contract)
    {
        if (_contracts.Count < _maximumContracts)
        {
            _contracts.Add(contract);
            Debug.Log($"Новый контракт. Заказчик={contract.Customer}. Предмет={contract.Item}");
            return true;
        }
        else
        {
            Debug.Log("No room for new contract");
            return false;
        }
    }
}
