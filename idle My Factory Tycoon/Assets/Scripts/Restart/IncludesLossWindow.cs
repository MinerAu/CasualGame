using System.Collections.Generic;
using UnityEngine;

public class IncludesLossWindow
{
    private List<GameObject> _menus;

    public IncludesLossWindow(List<GameObject> menus)
    {
        _menus = new List<GameObject>(menus);
    }

    public void OffWindows()
    {
        foreach (GameObject menu in _menus)
            if (menu.activeSelf == true)
                menu.SetActive(false);
    }
}
