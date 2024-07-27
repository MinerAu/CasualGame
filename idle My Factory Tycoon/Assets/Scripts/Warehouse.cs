using System.Collections.Generic;
using UnityEngine;

public class Warehouse : MonoBehaviour {
    public List<Item> resources;

    public void AddResource(Item resource) {
        int index = resources.FindIndex(r => r.nameItem == resource.nameItem);
        if (index == -1) {
            resources.Add(resource);
        }
        else {
            resources[index].quantityItem += resource.quantityItem;
        }
    }

    public void RemoveResource(Item resource) {
        int index = resources.FindIndex(r => r.nameItem == resource.nameItem);
        if (index != -1) {
            resources[index].quantityItem -= resource.quantityItem;
            if (resources[index].quantityItem <= 0) {
                resources.RemoveAt(index);
            }
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

    [ContextMenu("Покажи в консоли хранимые ресупрсы")]
    private void ShowResourcesInConsole() {
        foreach (Item item in resources) {
            Debug.Log($"Resource={item.nameItem}");
        }
    }
}

