using UnityEngine;

public class OpeningMenu : MonoBehaviour {

    [SerializeField] private GameObject menu;

    public void MenuOpening() {

        if (menu != null) {
            bool isActive = menu.activeSelf;
            menu.SetActive(!isActive);
        }
    }
}
