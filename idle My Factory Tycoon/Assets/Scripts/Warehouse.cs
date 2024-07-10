using System.Collections.Generic;
using UnityEngine;

public class Warehouse : MonoBehaviour
{
    [SerializeField] private List<Item> resources;

    public void AddResource(Item resource)
    {
        int index = resources.FindIndex(r => r.Name == resource.Name);
        if (index == -1)
        {
            resources.Add(resource);
        }
        else
        {
            resources[index].Quantity += resource.Quantity;
        }
    }

    public void RemoveResource(Item resource)
    {
        int index = resources.FindIndex(r => r.Name == resource.Name);
        if (index != -1)
        {
            resources[index].Quantity -= resource.Quantity;
            if (resources[index].Quantity <= 0)
            {
                resources.RemoveAt(index);
            }
        }
    }

    public Item GetResource(string name)
    {
        int index = resources.FindIndex(r => r.Name == name);
        return index != -1 ? resources[index] : null;
    }
}

