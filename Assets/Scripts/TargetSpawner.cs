using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject normalPrefab;
    [SerializeField] private GameObject bonusPrefab;
    [SerializeField] private GameObject dangerousPrefab;

    [Header("Spawn Area")]
    [SerializeField] private float areaSize = 8f;

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            SpawnTarget();
        }
    }

    private void OnEnable()
    {
        GameEvents.OnTargetDestroyed += SpawnAfterDestroy;
    }

    private void OnDisable()
    {
        GameEvents.OnTargetDestroyed -= SpawnAfterDestroy;
    }

    public void SpawnTarget()
    {
        TargetType type = GetRandomTargetType();

        Vector3 position = new Vector3(
            Random.Range(-areaSize, areaSize),
            -5f,
            Random.Range(-areaSize, areaSize)
        );

        TargetFactory.CreateTarget(
            type,
            position,
            normalPrefab,
            bonusPrefab,
            dangerousPrefab
        );
    }

    private void SpawnAfterDestroy(int total)
    {
        SpawnTarget();
    }

    private TargetType GetRandomTargetType()
    {
        int random = Random.Range(0, 100);

        if (random < 60)
            return TargetType.Normal;

        if (random < 85)
            return TargetType.Bonus;

        return TargetType.Dangerous;
    }
}