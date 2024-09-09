using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Warehouse : MonoBehaviour
{
    public List<Item> resources;
    public event UnityAction<string, int> ResourcesAmountChanged;

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

    [ContextMenu("������ � ������� �������� ��������")]
    private void ShowResourcesInConsole() {
        foreach (Item item in resources) {
            Debug.Log($"Resource={item.nameItem}");
        }
    }
}

