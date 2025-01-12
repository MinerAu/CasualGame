using UnityEngine;

public class Item : MonoBehaviour
{
    public Texture2D imageItem;
    public int coinsItem;
    public string nameItem;
    public int quantityItem;

    public Item(string name, int amount)
    {
        nameItem = name;
        quantityItem = amount;
    }
}
