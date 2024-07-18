using System.Collections.Generic;
using UnityEngine;
using Button = UnityEngine.UI.Button;

[RequireComponent(typeof(ProductChecker))]
[RequireComponent(typeof(Wallet))]
public class ProductionGoods : MonoBehaviour {

    private ProductChecker productChecker;
    private Wallet wallet;

    [SerializeField] private Button[] buttons;
    [SerializeField] private Product[] product;
    [SerializeField] private List<string> finisheGoods = new List<string>();

    [SerializeField] private Warehouse warehouse;

    private string[] items = new string[] {
        "Chair", "Door", "Table", "Hammer", "Saw", "Wheel", "Engine", "Bathroom", "Crewdriver", "Smartphone"
    };

    private void Start() {
        productChecker = GetComponent<ProductChecker>();
        wallet = GetComponent<Wallet>();
    }

    public void MakeProduct(Button clickedButton) {
        int index = System.Array.IndexOf(buttons, clickedButton);
        if (index != -1) {
            Product currentProduct = product[index];
            if (productChecker.IsProductAvailbale(currentProduct)) {
                if (wallet.GetCoins() >= currentProduct._price) {
                    foreach (var resurse in warehouse.resources) {
                        foreach (var resurse2 in currentProduct._requiredResources) {
                            if (resurse2.nameItem == resurse.nameItem) {
                                resurse.quantityItem -= resurse2.quantityItem;
                            }
                        }
                    }
                    int price = currentProduct._price;
                    foreach (string item in items) {
                        if (currentProduct._name == item) {
                            wallet.SpendCoins(price);
                            finisheGoods.Add(currentProduct._name);
                        }
                    }
                }
            }
        }
    }
}