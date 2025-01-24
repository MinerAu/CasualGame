using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContractsManager : MonoBehaviour
{
    [SerializeField] private Warehouse _warehouse;
    [SerializeField] private Wallet2 _wallet;
    [SerializeField] private Messenger _messenger;

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

    public void ClearContracts()
    {
        _contracts.Clear();
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
                    //Debug.Log("Контракт исполнен!!!");
                    _warehouse.RemoveProduct(requiredProduct, requiredAmount);
                    _wallet.AddCoins(contract.Award);
                    _contracts.RemoveAt(contractIndex);

                    _messenger.AddMessage("Контракт исполнен!", Color.green);

                    continue;
                }

                contractIndex++;
            }

            yield return delay;

            //Debug.Log("Control contracts cycle iteration");
        }
    }

    public int GetContractsCount() => _contracts.Count;
    public int GetContractId(int contractIndex) => _contracts[contractIndex].Id;
    public string GetContractCustomer(int contractIndex) => _contracts[contractIndex].Customer;
    public string GetContractItem(int contractIndex) => _contracts[contractIndex].Item;
    public int GetContractAmount(int contractIndex) => _contracts[contractIndex].Amount;
    public int GetContractDuration(int contractIndex) => _contracts[contractIndex].Duration;
    public int GetContractAward(int contractIndex) => _contracts[contractIndex].Award;
    public float GetContractAcceptedTime(int contractIndex) => _contracts[contractIndex].AcceptedTime;
    public string GetContractAsString(int contractIndex) => _contracts[contractIndex].ToString();
}
