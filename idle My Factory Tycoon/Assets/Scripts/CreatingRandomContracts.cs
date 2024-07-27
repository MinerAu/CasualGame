using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CreatingRandomContracts : MonoBehaviour {

    [SerializeField] private Image images;
    [SerializeField] private Sprite[] sprites;

    [SerializeField] private Transform pivot;

    private string[] ÒompanyNames = {
        "IVEY", "STROI", "RAGDIAN"
    };

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            RandomAssignments();
            Instantiate(images, pivot);
        }
    }

    public void RandomAssignments() {
        TextMeshProUGUI[] texts = images.GetComponentsInChildren<TextMeshProUGUI>();
        Image[] childImages = images.GetComponentsInChildren<Image>();
        foreach (Image childImage in childImages) {
            if (childImage.name == "ChildImage") {
                childImage.sprite = sprites[Random.Range(0, sprites.Length)];
            }
        }
        texts[0].text = ÒompanyNames[Random.Range(0, ÒompanyNames.Length)];
        texts[1].text = Random.Range(5, 16).ToString();
        texts[2].text = Random.Range(1, 7) + " ÌÂ‰ÂÎË";
        texts[3].text = Random.Range(300, 2001).ToString();
    }

}
