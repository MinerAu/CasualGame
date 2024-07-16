using System.Collections.Generic;
using UnityEngine;

public class Warehouse : MonoBehaviour
{
    [SerializeField] private List<Item> resources;

    public void AddResource(Item resource)
    {
        int index = resources.FindIndex(r => r.nameItem == resource.nameItem);
        if (index == -1)
        {
            resources.Add(resource);
        }
        else
        {
            resources[index].quantityItem += resource.quantityItem;
        }
    }

    public void RemoveResource(Item resource)
    {
        int index = resources.FindIndex(r => r.nameItem == resource.nameItem);
        if (index != -1)
        {
            resources[index].quantityItem -= resource.quantityItem;
            if (resources[index].quantityItem <= 0)
            {
                resources.RemoveAt(index);
            }
        }
    }

    public Item GetResource(string name)
    {
        Item result = null;
        foreach (Item item in resources)
        {
            if (item.name == name)
            {
                result = item;
                break;
            }
        }

        return result;

        /*int index = resources.FindIndex(r => r.nameItem == name);
        return index != -1 ? resources[index] : null;*/
    }

    [ContextMenu("Покажи в консоли хранимые ресупрсы")]
    private void ShowResourcesInConsole()
    {
        foreach (Item item in resources)
        {
            Debug.Log($"Resource={item.name}");
        }
    }
}

