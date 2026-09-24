using System;

public static class GameEvents
{
    public static Action<int> OnScoreChanged;
    public static Action<int> OnTargetDestroyed;
    public static Action<float> OnTimeChanged;
    public static Action OnGameOver;

    public static void ScoreChanged(int score)
    {
        OnScoreChanged?.Invoke(score);
    }

    public static void TargetDestroyed(int total)
    {
        OnTargetDestroyed?.Invoke(total);
    }

    public static void TimeChanged(float time)
    {
        OnTimeChanged?.Invoke(time);
    }

    public static void GameOver()
    {
        OnGameOver?.Invoke();
    }
}