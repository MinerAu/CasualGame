using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;



public class ProductChecker : MonoBehaviour
{
    [SerializeField] private Warehouse _warehouse;
    [SerializeField] private ResourcesShop _shop;

    public bool IsProductAvailbale(Product product)
    {
        bool enoughResources = true;

        Dictionary<string, int> requiredResources = product.GetRequiredResources();

        foreach (KeyValuePair<string, int> pair in requiredResources)
        {
            enoughResources &= _warehouse.GetResource(pair.Key).quantityItem >= pair.Value;

            if (!enoughResources)
            {
                Debug.Log($"Недостаточно ресурса [{pair.Key}]!");
                return enoughResources;
            }
        }

        return enoughResources;
    }

    public void TakeResourcesForProductFromWarehouse(Product product)
    {
        Debug.Log("Take resources!!!");

        Dictionary<string, int> requiredResources = product.GetRequiredResources();

        foreach (KeyValuePair<string, int> pair in requiredResources)
        {
            _warehouse.RemoveResource(pair.Key, pair.Value);

        }
    }
}
