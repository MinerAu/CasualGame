using UnityEngine;

public class ProductChecker : MonoBehaviour {
    [SerializeField] private Warehouse _warehouse;

    public bool IsProductAvailbale(Product product) {
        bool result = true;

        for (int i = 0; i < product.RequiredResourcesListCapacity; i++) {
            result &= _warehouse.GetResource(product.GetRequiredResourceName(i)).Quantity >= product.GetRequiredResourceAmount(i);

            if (result == false) {
                break;
            }
        }

        return result;
    }
}
