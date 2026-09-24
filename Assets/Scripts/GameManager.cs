using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private TargetSpawner spawner;
    [SerializeField] private float gameDuration = 30f;

    private float currentTime;
    private int score;
    private int targetsDestroyed;

    private bool gameOver;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        currentTime = gameDuration;

        GameEvents.ScoreChanged(score);
        GameEvents.TargetDestroyed(targetsDestroyed);
        GameEvents.TimeChanged(currentTime);
    }

    private void Update()
    {
        if (gameOver)
            return;

        currentTime -= Time.deltaTime;

        GameEvents.TimeChanged(currentTime);

        if (currentTime <= 0)
        {
            currentTime = 0;
            gameOver = true;

            GameEvents.TimeChanged(currentTime);
            GameEvents.GameOver();
        }
    }

    public void TargetHit(int points)
    {
        if (gameOver)
            return;

        if (!PlayerController.isShielded)
        {
            score += points;
        }
        
        targetsDestroyed++;

        GameEvents.ScoreChanged(score);
        GameEvents.TargetDestroyed(targetsDestroyed);
    }
}