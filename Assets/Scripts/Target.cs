using UnityEngine;

public enum TargetType
{
    Normal,
    Bonus,
    Dangerous
}
public class Target : MonoBehaviour
{
    public TargetType Type { get; private set; }

    private int points;

    public void Initialize(TargetType type)
    {
        Type = type;

        switch (type)
        {
            case TargetType.Normal:
                points = 10;
                break;

            case TargetType.Bonus:
                points = 25;
                break;

            case TargetType.Dangerous:
                points = -10;
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        GameManager.Instance.TargetHit(points);

        Destroy(gameObject);
    }
}