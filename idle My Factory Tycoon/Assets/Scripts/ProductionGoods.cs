using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using UnityEngine;
using Button = UnityEngine.UI.Button;

[RequireComponent(typeof(ProductChecker))]
public class ProductionGoods : MonoBehaviour
{

    [SerializeField] private Button[] buttons;
    [SerializeField] private Product[] products;

    [SerializeField] private QuantitySet quantitySet;
    [SerializeField] private Warehouse warehouse;
    [SerializeField] private TimeManager secondsElapsed;
    [SerializeField] private AdjacentWorkersAndMachinesIncluded check;
    [SerializeField] private StartProduction startProduction;
    [SerializeField] private Wallet wallet;
    [SerializeField] ContractsManager contract;

    private ProductChecker productChecker;
    private Product Product;
    private Dictionary<string, bool> items = new Dictionary<string, bool> {
        { "Chair", true },
        { "Door", true },
        { "Table", true },
        { "Hammer", true },
        { "Saw", true },
        { "Wheel", true },
        { "Engine", true },
        { "Bathroom", true },
        { "Crewdriver", true },
        { "Smartphone", true }
    };

    [SerializeField] private List<string> finisheGoods;

    private int sumSecondsWeek = 0;
    private float currentTime = 0;
    public bool isValue = false;

    private void Start()
    {
        productChecker = GetComponent<ProductChecker>();
    }

    /*private void Update()
    {
        if (isValue)
        {
            if (!productChecker.IsProductAvailbale(Product))
            {
                startProduction.StopProductionAnimation();
            } 
        }
        if (isValue)
        {
            currentTime += Time.deltaTime * 1f;
        }
    }*/

    /*public void MakeProduct(Button clickedButton)
    {
        var index = Array.IndexOf(buttons, clickedButton);
        if (index != -1 && check.IsEnabled())
        {
            StartCoroutine(ProduceProduct(product[index]));
        }
    }

    private IEnumerator ProduceProduct(Product currentProduct)
    {
        Debug.Log($"Produce product");
        if (productChecker.IsProductAvailbale(currentProduct))
        {
            Product = currentProduct;
            isValue = true;
            startProduction.StartProductionAnimation();
            yield return new WaitForSeconds(startProduction.speedWorkersLVL1);

            var requiredResources = currentProduct._requiredResources.ToDictionary(r => r.nameItem, r => r.quantityItem);

            int totalProduced = 0;

            //for (var i = 0; i < quantitySet.quantity; i++)
            for (var i = 0; i < 1; i++)
            {
                Debug.Log($"i={i}");
                int productsToProduce = check.SumWorkersMachine();

                for (int j = 0; j < productsToProduce; j++)
                {
                    if (totalProduced < quantitySet.quantity)
                    {
                        AddFinishedGood(currentProduct._name, currentProduct);
                        OverkillResources(warehouse, requiredResources, currentProduct);
                        totalProduced++;
                    }
                }

                int countWeek = contract.contract.Duration;
                int weekDuration = 40;
                int penaltyFee = 0;
                int justWeeks = weekDuration * countWeek;
                Debug.Log("justWeeks " + justWeeks);
                Debug.Log("currentTime" + currentTime);

                if (currentTime < justWeeks)
                {
                    if (finisheGoods.Count >= contract.contract.Amount)
                    {
                        Debug.Log("Вы выполнили требования контракта!");
                        isValue = false;
                        startProduction.StopProductionAnimation();
                        yield break;
                    }
                }

                yield return new WaitForSeconds(startProduction.speedWorkersLVL1);

                if (true)
                {
                    if (currentTime > justWeeks)
                    {
                        Debug.Log("Налог");
                        penaltyFee = (int)((contract.contract.Award / justWeeks) * currentTime);
                        wallet.SpendCoins(penaltyFee);
                        isValue = false;
                        startProduction.StopProductionAnimation();
                        yield break;
                    }
                }
            }
            startProduction.StopProductionAnimation();
        }
    }

    private void AddFinishedGood(string productName, Product currentProduct)
    {
        if (productChecker.IsProductAvailbale(currentProduct))
        {
            if (items.ContainsKey(productName))
            {
                finisheGoods.Add(productName);
            }
        }
    }

    private void OverkillResources(Warehouse warehouse, Dictionary<string, int> requiredResources, Product currentProduct)
    {
        Debug.Log("OverkillResources");

        foreach (var resource in requiredResources)
        {
            warehouse.RemoveResource(new Item(resource.Key, resource.Value));
        }

        /*foreach (var resource in warehouse.resources)
        {
            if (requiredResources.TryGetValue(resource.nameItem, out var quantity))
            {
                if (productChecker.IsProductAvailbale(currentProduct))
                {
                    //resource.quantityItem -= quantity;
                    warehouse.RemoveResource()
                }
            }
        }
    }*/

    public void MakeProduct(Product product)
    {
        if (check.TryGetFreeWorker(out Worker worker) && productChecker.IsProductAvailbale(product))
        {
            StartCoroutine(worker.Produce(product));
        }
        else
        {
            Debug.Log($"Не могу создать [{product._name}]!");
        }
    }
}