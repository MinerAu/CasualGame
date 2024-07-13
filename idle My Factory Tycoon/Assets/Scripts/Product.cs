using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Masalkin632(2024-07-13): ������� (�����), ������ ��: "���� ������� ������ � ������� ����� ��������� ��� ���������� "������" ����� ��� ������������"
//TODO: �������� � �������� - ����������� ������������!!!
public class Product : MonoBehaviour
{
    [Header("��������� ������������� ������")]
    [Tooltip("������������")]
    [SerializeField] private string _name;
    [Tooltip("����������")]
    [SerializeField] private int _amount;
    [Tooltip("���� �������")]
    [SerializeField] private int _price;

    [Header("��������� ��� ������������ �������")]
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
