using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductChecker : MonoBehaviour
{
    [SerializeField] private Warehouse _warehouse;

    private bool IsProductAvailbale(Product product)
    {
        bool result = true;

        for (int i = 0; i < product.RequiredResourcesListCapacity; i++)
        {
            result &= _warehouse.GetResource(product.GetRequiredResourceName(i)).Quantity >= product.GetRequiredResourceAmount(i);

            if (result == false)
            {
                break;
            }
        }

        return result;
    }
}
