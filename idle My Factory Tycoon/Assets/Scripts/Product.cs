using System.Collections.Generic;
using UnityEngine;


//Masalkin632(2024-07-13): ������� (�����), ������ ��: "���� ������� ������ � ������� ����� ��������� ��� ���������� "������" ����� ��� ������������"
//TODO: �������� � �������� - ����������� ������������!!!
public class Product : MonoBehaviour
{
    [Header("��������� ������������� ������")]
    [Tooltip("������������")]
    public string _name;
    [Tooltip("������������ �� �������")]
    public string _russianName;
    [Tooltip("����������")]
    public int _amount;
    [Tooltip("���� �������")]
    public int _price;
    [Tooltip("2D ������ ������")]
    public Sprite _image;
    [Tooltip("�����������")]
    public int _complexity;

    [Header("��������� ��� ������������ �������")]
    public List<Item> _requiredResources;

    public int RequiredResourcesListCapacity => _requiredResources.Count;

    public Dictionary<string, int> GetRequiredResources()
    {
        Dictionary<string, int> result = new Dictionary<string, int>();

        foreach (Item item in _requiredResources)
        {
            if (result.ContainsKey(item.nameItem))
            {
                result[item.nameItem]++;
            }
            else
            {
                result.Add(item.nameItem, 1);
            }
        }

        return result;
    }
    /*public string GetRequiredResourceName(int requiredResourcesIndex)
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
    }*/
}
