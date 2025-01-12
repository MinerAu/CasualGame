using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class ContractsCreator : MonoBehaviour
{
    private string[] _customers = new string[]
    {
        "Рога и копыта",
        "Смешарики",
        "ИваноСтрой",
        "Белоснежка и Ко",
        "РазДваТриМарин"
    };

    /*private string[] _items = new string[]
    {
        "стул",
        "стол",
        "ложка",
        "тарелка",
        "чашка"
    };*/

    private Product[] _products;

    public event UnityAction<Contract> ContractCreated;

    private void Start()
    {
        FormArrayOfProducts();
        GenerateThreeRandomContracts();
    }

    public Contract CreateRandomContract()
    {
        int minAmount = 3;
        int maxAmount = 7;

        string customer = Randomizer.GetObjectFromArray(_customers).ToString();
        string item = Randomizer.GetObjectFromArray(_products.Select(x => x._russianName).ToArray()).ToString();
        int Amount = Randomizer.GetNumber(minAmount, maxAmount);
        int duration = Mathf.Clamp(Amount * 2 + Randomizer.GetNumber(-3, 3), 1, 7);
        int award = (int)Mathf.Round(GetItemProducingCost(item) * Amount * 2.2f);

        Contract newcContract = new Contract(customer, item, Amount, duration, award);

        ContractCreated?.Invoke(newcContract);
        return newcContract;
    }

    private List<Contract> GenerateThreeRandomContracts()
    {
        int three = 3;
        List<Contract> contracts = new List<Contract>();

        for (int i = 1; i <= three; i++)
        {
            contracts.Add(CreateRandomContract());
        }

        return contracts;
    }

    private void FormArrayOfProducts()
    {
        //получить в _items список товаров
        GameObject items = GameObject.Find("Products");
        
        _products = items.GetComponentsInChildren<Product>();
    }

    private int GetItemProducingCost(string itemName)
    {
        int result = 0;

        foreach (Product product in _products)
        {
            if (product._russianName == itemName)
            {
                foreach (Item item in product._requiredResources)
                {
                    result += item.coinsItem;
                }
            }
        }

        return result;
    }
}
