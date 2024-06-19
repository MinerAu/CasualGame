using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Search;
using UnityEngine;

public class TreeItem : MonoBehaviour
{
    /*[SerializeField] private List<Texture2D> img = new List<Texture2D>();
    [SerializeField] private List<int> coins = new List<int>();
    [SerializeField] private List<string> nameItem = new List<string>();
    [SerializeField] private List<int> quantity = new List<int>();*/

    [SerializeField] private List<ShopItem> shopItems = new List<ShopItem>();
    [SerializeField] private List<WarehouseItem> warehouseItems = new List<WarehouseItem>();

    private List<Item> item = new List<Item>();

    public class ShopItem // �������� ���������� ��� �������� � ��������
    {
        public Texture2D texture;
        public int price;
        public string name;
        public int quantity = int.MaxValue; // ����������� ����������
    }

    public class WarehouseItem // �������� ���������� ��� �������� �� ������
    {
        public Texture2D texture;
        public string name;
        public int quantity; // ������������ ����������
        public bool isAvailable; // ���� ��� ����������� ����������� ������
    }

    private void Start()
    {
        LoadResources();

    }
    private void LoadResources()
    {
        Texture2D board = (Texture2D)Resources.Load("Textures/Resources/Board");
        Texture2D nailsBox = (Texture2D)Resources.Load("Textures/Resources/NailsBox");
        Texture2D metalSheet = (Texture2D)Resources.Load("Textures/Resources/MetalSheet");
        Texture2D nailsBox2 = (Texture2D)Resources.Load("Textures/Resources/NailsBox2");
        Texture2D metalAlloy = (Texture2D)Resources.Load("Textures/Resources/MetalAlloy");
        Texture2D rubber = (Texture2D)Resources.Load("Textures/Resources/Rubber");
        Texture2D plastic = (Texture2D)Resources.Load("Textures/Resources/Plastic");
        Texture2D circuitBoard = (Texture2D)Resources.Load("Textures/Resources/CircuitBoard");

        // �������� �������� ShopItem
        shopItems.Add(new ShopItem{texture = board, price = 8, name = "�����"});
        shopItems.Add(new ShopItem{texture = nailsBox, price = 8, name = "������� �������"});
        shopItems.Add(new ShopItem{texture = metalSheet, price = 8, name = "���� �������"});
        shopItems.Add(new ShopItem{texture = nailsBox2, price = 8, name = "������� �������"});
        shopItems.Add(new ShopItem{texture = metalAlloy, price = 8, name = "����� �������"});
        shopItems.Add(new ShopItem{texture = rubber, price = 8, name = "������"});
        shopItems.Add(new ShopItem{texture = plastic, price = 8, name = "����������"});
        shopItems.Add(new ShopItem{texture = circuitBoard, price = 8, name = "������������"});

        // �������� �������� WarehouseItem
        warehouseItems.Add(new WarehouseItem { texture = board, name = "�����", quantity = 0, isAvailable = false });
        warehouseItems.Add(new WarehouseItem { texture = nailsBox, name = "������� �������", quantity = 0, isAvailable = false});
        warehouseItems.Add(new WarehouseItem { texture = metalSheet,name = "���� �������", quantity = 0, isAvailable = false});
        warehouseItems.Add(new WarehouseItem { texture = nailsBox2, name = "������� �������", quantity = 0, isAvailable = false });
        warehouseItems.Add(new WarehouseItem { texture = metalAlloy, name = "����� �������", quantity = 0, isAvailable = false});
        warehouseItems.Add(new WarehouseItem { texture = rubber, name = "������", quantity = 0, isAvailable = false });
        warehouseItems.Add(new WarehouseItem { texture = plastic, name = "����������", quantity = 0, isAvailable = false });
        warehouseItems.Add(new WarehouseItem { texture = circuitBoard,name = "������������", quantity = 0, isAvailable = false });

    }

    
}
