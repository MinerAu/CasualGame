using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour {
    [SerializeField] private Sprite play;
    [SerializeField] private Sprite pause;
     
    private bool isPaused = false; 
    private Button button;

    private void Start() {
        button = GetComponent<Button>();
    }

    public void ButtonPause() {
        if (!isPaused) {
            button.image.sprite = play;     
            Time.timeScale = 0; 
            isPaused = true;
        }
        else {
            button.image.sprite = pause;
            Time.timeScale = 1;
            isPaused = false; 
        }
    }
}
