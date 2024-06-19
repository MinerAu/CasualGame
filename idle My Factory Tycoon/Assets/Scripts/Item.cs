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
    
}
