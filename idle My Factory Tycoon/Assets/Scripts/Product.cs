using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Masalkin632(2024-07-13): продукт (товар), Сергей Дю: "Надо сделать скрипт в котором будет храниться как получается "данный" товар при производстве"
//TODO: обсудить с командой - возможность наследования!!!
public class Product : MonoBehaviour
{
    [Header("Настройки производимого товара")]
    [Tooltip("Наименование")]
    [SerializeField] private string _name;
    [Tooltip("Количество")]
    [SerializeField] private int _amount;
    [Tooltip("Цена продажи")]
    [SerializeField] private int _price;

    [Header("Требуемые для производства ресурсы")]
    [SerializeField] private List<Item> _requiredResources;

    public int RequiredResourcesListCapacity => _requiredResources.Count;

    public string GetRequiredResourceName(int requiredResourcesIndex)
    {
        if (requiredResourcesIndex >= 0 && requiredResourcesIndex < _requiredResources.Count)
        {
            return _requiredResources[requiredResourcesIndex].name;
        }
        else
        {
            throw new System.ArgumentOutOfRangeException(nameof(requiredResourcesIndex));
        }
    }

    public int GetRequiredResourceAmount(int requiredResourcesIndex)
    {
        if (requiredResourcesIndex >= 0 && requiredResourcesIndex < _requiredResources.Count)
        {
            return _requiredResources[requiredResourcesIndex].Quantity;
        }
        else
        {
            throw new System.ArgumentOutOfRangeException(nameof(requiredResourcesIndex));
        }
    }
}
