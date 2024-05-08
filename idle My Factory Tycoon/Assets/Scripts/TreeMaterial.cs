using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMaterial : MonoBehaviour
{
    [SerializeField] private List<Texture2D> img = new List<Texture2D>();
    [SerializeField] private List<int> coins = new List<int>();
    [SerializeField] private List<string> nameMaterial = new List<string>();

    private List<Material> material = new List<Material>();

    private void Start()
    {

        for (int i = 0; i < img.Count; i++)
        {
            material.Add(new Material(img[i], coins[i], nameMaterial[i]));
        }

    }

}
