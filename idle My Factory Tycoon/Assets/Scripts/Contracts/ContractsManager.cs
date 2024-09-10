using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContractsManager : MonoBehaviour
{
    [SerializeField] private Warehouse _warehouse;
    [SerializeField] private Wallet _wallet;

    private int _maximumContracts = 3;
    private List<Contract> _contracts = new List<Contract>();
    private Coroutine _controlContractsProcess;

    private void OnEnable()
    {
        _controlContractsProcess = StartCoroutine(ControlContracts());
    }

    private void OnDisable()
    {
        StopCoroutine(_controlContractsProcess);
    }

    public bool AddContract(Contract contract)
    {
        if (_contracts.Count < _maximumContracts)
        {
            _contracts.Add(contract);
            Debug.Log($"New contract. Customer={contract.Customer}. Product={contract.Item}");
            return true;
        }
        else
        {
            Debug.Log("No room for new contract");
            return false;
        }
    }

    private IEnumerator ControlContracts()
    {
        var delay = new WaitForSecondsRealtime(0.025f);

        while (true)
        {
            int contractIndex = 0;

            while (contractIndex < _contracts.Count)
            {
                Contract contract = _contracts[contractIndex];
                string requiredProduct = contract.Item;
                int requiredAmount = contract.Amount;

                //Debug.Log($"Product=[{requiredProduct}]. Required=[{requiredAmount}]. At warehouse=[{_warehouse.GetProductAmount(requiredProduct)}]");

                if (_warehouse.GetProductAmount(requiredProduct) >= requiredAmount)
                {
                    Debug.Log("Контракт исполнен!!!");

                    _warehouse.RemoveProduct(requiredProduct, requiredAmount);
                    _wallet.AddCoins(contract.Award);
                    _contracts.RemoveAt(contractIndex);
                    continue;
                }

                contractIndex++;
            }

            yield return delay;

            //Debug.Log("Control contracts cycle iteration");
        }
    }
}
