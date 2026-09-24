using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text targetsText;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text gameOverText;

    private void OnEnable()
    {
        GameEvents.OnScoreChanged += UpdateScore;
        GameEvents.OnTargetDestroyed += UpdateTargets;
        GameEvents.OnTimeChanged += UpdateTimer;
        GameEvents.OnGameOver += ShowGameOver;
    }

    private void OnDisable()
    {
        GameEvents.OnScoreChanged -= UpdateScore;
        GameEvents.OnTargetDestroyed -= UpdateTargets;
        GameEvents.OnTimeChanged -= UpdateTimer;
        GameEvents.OnGameOver -= ShowGameOver;
    }

    private void UpdateScore(int score)
    {
        scoreText.text = $"Score: {score}";
    }

    private void UpdateTargets(int amount)
    {
        targetsText.text = $"Targets: {amount}";
    }

    private void UpdateTimer(float time)
    {
        timerText.text = $"Time: {Mathf.CeilToInt(time)}";
    }

    private void ShowGameOver()
    {
        gameOverText.gameObject.SetActive(true);
    }
}