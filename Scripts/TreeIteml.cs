using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeItem : MonoBehaviour
{
    [SerializeField] private List<Texture2D> img = new List<Texture2D>();
    [SerializeField] private List<int> coins = new List<int>();
    [SerializeField] private List<string> nameItem = new List<string>();

    private List<Item> item = new List<Item>();

    private void Start()
    {

        for (int i = 0; i < img.Count; i++)
        {
            item.Add(new Item(img[i], coins[i], nameItem[i]));
        }

    }

}
