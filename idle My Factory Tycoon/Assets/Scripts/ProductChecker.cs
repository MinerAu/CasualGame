using UnityEngine;

public class ProductChecker : MonoBehaviour
{
    [SerializeField] private Warehouse _warehouse;

    public bool IsProductAvailbale(Product product)
    {
        bool result = true;

        for (int i = 0; i < product.RequiredResourcesListCapacity; i++)
        {
            string requiredResourceName = product.GetRequiredResourceName(i);
            result &= _warehouse.GetResource(requiredResourceName).quantityItem >= product.GetRequiredResourceAmount(i);

            if (result == false)
            {
                break;
            }
        }

        //if (result)
        //{
        //    Debug.Log("Enough resources");
        //}
        //else
        //{
        //    Debug.Log("Not enough resources");
        //}

        return result;
    }
}
