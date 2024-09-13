using System.Collections.Generic;
using UnityEngine;

public class OpeningMenu : MonoBehaviour {

    [SerializeField] private GameObject _activatedMenu;
    [SerializeField] private List<GameObject> _otherMenus;

    public void MenuOpening() {

        if (_activatedMenu != null)
        {
            if (_activatedMenu.activeSelf)
            {
                _activatedMenu.SetActive(false);
            }
            else
            {
                foreach (GameObject otherMenu in _otherMenus)
                {
                    otherMenu.SetActive(false);
                }

                _activatedMenu.SetActive(true);
            }
        }
    }
}
