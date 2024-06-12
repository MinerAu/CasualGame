using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Texture2D imageItem { get; set; }
    public int coinsItem { get; set; }
    public string nameItem { get; set; }
    public int quantityItem { get; set; }

    public Item(Texture2D im, int coin, string name, int quantity)
    {
        imageItem = im;
        coinsItem = coin;
        nameItem = name;
        quantityItem = quantity;
    }
    /*public Item()
    {
        Item board = new Item { nameItem ="Доска", coinsItem = 8, quantityItem = 1 };
        Item nailsBox = new Item { nameItem ="Коробка гвоздей", coinsItem = 8, quantityItem = 1 };
        Item metalSheet = new Item { nameItem ="Лист металла", coinsItem = 8, quantityItem = 1 };
        Item nailsBox2 = new Item { nameItem ="Коробка шурупов", coinsItem = 8, quantityItem = 1 };
        Item matalAlloy = new Item { nameItem ="Сплав металла", coinsItem = 8, quantityItem = 1 };
        Item rubber = new Item { nameItem ="Резина", coinsItem = 8, quantityItem = 1 };
        Item plastic = new Item { nameItem ="Пластмасса", coinsItem = 8, quantityItem = 1 };
        Item circuitBoard = new Item { nameItem ="Электросхема", coinsItem = 8, quantityItem = 1 };
    }  */
    
}
