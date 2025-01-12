using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ResourcesShop : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Warehouse _warehouse;

    public event UnityAction<string, int> ResourcesAmountChanged;

    public void BuyResource(string resourceName)
    {
        Item resource = _warehouse.GetResource(resourceName);

        if (resource == null)
        {
            Debug.Log($"No Resource With Name={resourceName}");
            return;
        }

        if (_wallet.SpendCoins(resource.coinsItem))
        {
            //resource.quantityItem++;
            _warehouse.AddResource(resourceName, 1);
            //ResourcesAmountChanged?.Invoke(resourceName, resource.quantityItem);
            ResourcesAmountChanged?.Invoke("coins", _wallet.GetCoins());
        }
    }
}
