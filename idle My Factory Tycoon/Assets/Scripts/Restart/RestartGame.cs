using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    [SerializeField] private GameObject _loss;

    public void Restart()
    {
        SceneManager.LoadScene(0);
        _loss.SetActive(false);
    }
}
