using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Product))]
[RequireComponent(typeof(ProductChecker))]
[RequireComponent(typeof(Wallet))]
[RequireComponent(typeof(Warehouse))]

public class ProductionGoods : MonoBehaviour {

    private Product product;
    private ProductChecker productChecker;
    private Wallet wallet;
    private Warehouse warehouse;

    [SerializeField] private List<string> finisheGoods = new List<string>();

    private void Start() {
        product = GetComponent<Product>();
        productChecker = GetComponent<ProductChecker>();
        wallet = GetComponent<Wallet>();
        warehouse = GetComponent<Warehouse>();
    }

    private void Update() {
    }

    public void MakeProduct() {
        if (productChecker.IsProductAvailbale(product)) {
            wallet.SpendCoins(60);
            if (wallet.GetCoins() >= 60) {
                finisheGoods.Add(product._name);
                Debug.Log(finisheGoods[0]);
            }
        }
    }
}
