using System.Collections.Generic;
using UnityEngine;


//Masalkin632(2024-07-13): продукт (товар), Сергей Дю: "Надо сделать скрипт в котором будет храниться как получается "данный" товар при производстве"
//TODO: обсудить с командой - возможность наследования!!!
public class Product : MonoBehaviour
{
    [Header("Настройки производимого товара")]
    [Tooltip("Наименование")]
    public string _name;
    [Tooltip("Наименование на русском")]
    public string _russianName;
    [Tooltip("Количество")]
    public int _amount;
    [Tooltip("Цена продажи")]
    public int _price;
    [Tooltip("2D иконка товара")]
    public Sprite _image;

    [Header("Требуемые для производства ресурсы")]
    public List<Item> _requiredResources;

    public int RequiredResourcesListCapacity => _requiredResources.Count;

    public string GetRequiredResourceName(int requiredResourcesIndex)
    {
        if (requiredResourcesIndex >= 0 && requiredResourcesIndex < _requiredResources.Count)
        {
            return _requiredResources[requiredResourcesIndex].nameItem;
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
            return _requiredResources[requiredResourcesIndex].quantityItem;
        }
        else
        {
            throw new System.ArgumentOutOfRangeException(nameof(requiredResourcesIndex));
        }
    }
}
