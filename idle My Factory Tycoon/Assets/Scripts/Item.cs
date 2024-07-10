using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private int _price;
    [SerializeField] private int _quantity;
    [SerializeField] private Sprite _icon;

    public string Name { get => _name; }
    public int Price { get => _price; }
    public int Quantity { get => _quantity; set => _quantity = value; }
    public Sprite Icon { get => _icon; }
}

