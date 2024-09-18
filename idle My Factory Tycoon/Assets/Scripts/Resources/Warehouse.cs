using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Warehouse : MonoBehaviour
{
    public List<Item> resources;
    public List<Product> products;

    public event UnityAction<string, int> ResourcesAmountChanged;
    public event UnityAction<string, int> ProductsAmountChanged;

    public void AddResource(string resourceName, int resourceAmount)
    {
        int index = resources.FindIndex(r => r.nameItem == resourceName);

        if (index == -1)
        {
            Debug.Log("unknown resource!!!");
        }
        else
        {
            resources[index].quantityItem += resourceAmount;
            ResourcesAmountChanged?.Invoke(resources[index].nameItem, resources[index].quantityItem);
        }
    }

    public void RemoveResource(string resourceName, int resourceAmount)
    {
        int index = resources.FindIndex(r => r.nameItem == resourceName);

        if (index == -1)
        {
            Debug.Log("unknown resource!!!");
        }
        else
        {
            resources[index].quantityItem -= resourceAmount;
            ResourcesAmountChanged?.Invoke(resources[index].nameItem, resources[index].quantityItem);
        }
    }

    public Item GetResource(string name) {
        Item result = null;
        foreach (Item item in resources) {
            if (item.nameItem == name) {
                result = item;
            }
        }
        return result;
    }

    public void AddProduct(string productName, int productAmount)
    {
        int index = products.FindIndex(p => p._name == productName);

        if (index == -1)
        {
            index = products.FindIndex(p => p._russianName == productName);
            
            if (index == -1)
            {
                Debug.Log("Error: unknown resource!");
            }
            else
            {
                products[index]._amount += productAmount;
                ProductsAmountChanged?.Invoke(productName, productAmount);
            }
        }
        else
        {
            products[index]._amount += productAmount;
            ProductsAmountChanged?.Invoke(productName, productAmount);
        }
    }

    public void RemoveProduct(string productName, int productAmount)
    {
        int index = products.FindIndex(p => p._name == productName);

        if (index == -1)
        {
            index = products.FindIndex(p => p._russianName == productName);

            if (index == -1)
            {
                Debug.Log("Error: unknown resource!");
            }
            else
            {
                products[index]._amount -= productAmount;
                ProductsAmountChanged?.Invoke(productName, productAmount);
            }
        }
        else
        {
            products[index]._amount -= productAmount;
            ProductsAmountChanged?.Invoke(productName, productAmount);
        }
    }

    public int GetProductAmount(string productName)
    {
        int index = products.FindIndex(p => p._name == productName);

        if (index == -1)
        {
            index = products.FindIndex(p => p._russianName == productName);

            if (index == -1)
            {
                return 0;
            }
            else
            {
                return products[index]._amount;
            }
        }
        else
        {
            return products[index]._amount;
        }
    }

    [ContextMenu("Покажи в консоли хранимые ресупрсы")]
    private void ShowResourcesInConsole() {
        foreach (Item item in resources) {
            Debug.Log($"Resource={item.nameItem}");
        }
    }
}

