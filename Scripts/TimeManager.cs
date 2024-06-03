using UnityEngine;
using UnityEngine.UI;
public class TimeManager : MonoBehaviour
{
    public float timeScale = 1f; // скорость течения времени
    public float weekDuration = 30f; // Длительность одной игровой недели

    private float currentTime = 0f;
    private int currentWeek = 0;

    public Text weekText; // Ссылка на UI-элемент где будет отображаться текущая неделя

    private void Start()
    {
        InvokeRepeating("UpdateWeek", 0f, weekDuration / timeScale);
    }

    private void UpdateWeek()
    {
        currentWeek++;
        OnWeekPassed(currentWeek);
        UpdateWeekUI();
    }

    private void Update()
    {
        currentTime += Time.deltaTime * timeScale;
    }

    public int GetCurrentWeek()
    {
        return currentWeek;
    }

    protected virtual void OnWeekPassed(int week)
    {
        // Вызывается каждую неделю, можно добавить свою логику
        Debug.Log($"Week {week} has passed!");
    }

    private void UpdateWeekUI()
    {
        if ( weekText != null )
        {
            weekText.text = $"Week {currentWeek}";
        }
    }
}
