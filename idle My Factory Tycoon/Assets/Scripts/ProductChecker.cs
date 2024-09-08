using UnityEngine;

public class ProductChecker : MonoBehaviour
{
    [SerializeField] private Warehouse _warehouse;

    public bool IsProductAvailbale(Product product)
    {
        bool enoughResources = true;

        for (int i = 0; i < product.RequiredResourcesListCapacity; i++)
        {
            string requiredResourceName = product.GetRequiredResourceName(i);
            enoughResources &= _warehouse.GetResource(requiredResourceName).quantityItem >= product.GetRequiredResourceAmount(i);

            if (enoughResources == false)
            {
                Debug.Log("Недостаточно ресурсов!");
                return enoughResources;
            }
        }

        return enoughResources;
    }
}
