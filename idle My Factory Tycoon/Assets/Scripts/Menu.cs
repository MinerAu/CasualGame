using UnityEngine;

public class Menu : MonoBehaviour {

    [SerializeField] private GameObject[] menuPrducts;

    private void Update() {
        if (Input.GetKey(KeyCode.Escape)) {
            for (int i = 0; i < menuPrducts.Length; i++) {
                menuPrducts[i].SetActive(false);
            }
        }
    }
}
