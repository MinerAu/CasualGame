using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Button = UnityEngine.UI.Button;

[RequireComponent(typeof(ProductChecker))]
public class ProductionGoods : MonoBehaviour {

    [SerializeField] private Button[] buttons;
    [SerializeField] private Product[] product;

    [SerializeField] private QuantitySet quantitySet;
    [SerializeField] private Warehouse warehouse;
    [SerializeField] private TimeManager secondsElapsed;
    [SerializeField] private AdjacentWorkersAndMachinesIncluded check;
    [SerializeField] private StartProduction startProduction;
    [SerializeField] private ContractSpawner contractSpawner;
    [SerializeField] private Wallet wallet;

    private ProductChecker productChecker;
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

    [SerializeField] private List<string> finisheGoods = new List<string>();

    private int sumSecondsWeek = 0;
    private float currentTime = 0;

    public bool isValue = false;

    private void Start() {
        productChecker = GetComponent<ProductChecker>();
        finisheGoods = new List<string>();
    }

    private void Update() {
        if (isValue) {
            currentTime += Time.deltaTime * 1f;
        }
    }

    public void MakeProduct(Button clickedButton) {
        var index = Array.IndexOf(buttons, clickedButton);
        if (index != -1 && check.IsEnabled()) {
            StartCoroutine(ProduceProduct(product[index]));
        }
    }

    private IEnumerator ProduceProduct(Product currentProduct) {
        if (productChecker.IsProductAvailbale(currentProduct)) {
            isValue = true;
            startProduction.StartProductionAnimation();
            yield return new WaitForSeconds(startProduction.speedWorkersLVL1);

            var requiredResources = currentProduct._requiredResources.ToDictionary(r => r.nameItem, r => r.quantityItem);

            int totalProduced = 0;

            for (var i = 0; i < quantitySet.quantity; i++) {
                int productsToProduce = check.SumWorkersMachine();

                for (int j = 0; j < productsToProduce; j++) {
                    if (totalProduced < quantitySet.quantity) {
                        AddFinishedGood(currentProduct._name, currentProduct);
                        OverkillResources(warehouse, requiredResources, currentProduct);
                        totalProduced++;
                    }
                }

                int countWeek = 2;//contractSpawner.countWeek;
                int weekDuration = 40; //startProduction.weekDuration;
                int penaltyFee = 0;

                int justWeeks = weekDuration * countWeek;
                Debug.Log(justWeeks);
                Debug.Log(currentTime);

                if (currentTime < justWeeks) {
                    if (finisheGoods.Count >= 10) { //contractSpawner.countProduct) {
                        Debug.Log("Вы выполнили требования контракта!");
                        isValue = false;
                        startProduction.StopProductionAnimation();
                        yield break;
                    }
                }
                yield return new WaitForSeconds(startProduction.speedWorkersLVL1);

                if (contractSpawner.isCancellationContract) {
                    contractSpawner.isCancellationContract = false;
                    startProduction.StopProductionAnimation();
                    yield break;
                }
                if (contractSpawner.isCancellationContract) {
                    if (currentTime > 10) {
                        Debug.Log("Налог");
                        penaltyFee = (int)((contractSpawner.coutMoney / justWeeks) * currentTime);
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

    private void AddFinishedGood(string productName, Product currentProduct) {
        if (productChecker.IsProductAvailbale(currentProduct)) {
            if (items.ContainsKey(productName)) {
                finisheGoods.Add(productName);
            }
        }
    }

    private void OverkillResources(Warehouse warehouse, Dictionary<string, int> requiredResources, Product currentProduct) {
        foreach (var resource in warehouse.resources) {
            if (requiredResources.TryGetValue(resource.nameItem, out var quantity)) {
                if (productChecker.IsProductAvailbale(currentProduct)) {
                    resource.quantityItem -= quantity;
                }
            }
        }
    }
}