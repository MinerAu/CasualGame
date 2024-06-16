using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material : MonoBehaviour
{
    public Texture2D imageMaterial { get; set; }
    public int coinsMaterial { get; set; }
    public string nameMaterial { get; set; }

    public Material(Texture2D im, int coin, string name)
    {
        imageMaterial = im;
        coinsMaterial = coin;
        nameMaterial = name;
    }

}
