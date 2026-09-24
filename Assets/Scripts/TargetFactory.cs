using UnityEngine;

public static class TargetFactory
{
    public static Target CreateTarget(
        TargetType type,
        Vector3 position,
        GameObject normalPrefab,
        GameObject bonusPrefab,
        GameObject dangerousPrefab)
    {
        GameObject prefab = null;

        switch (type)
        {
            case TargetType.Normal:
                prefab = normalPrefab;
                break;

            case TargetType.Bonus:
                prefab = bonusPrefab;
                break;

            case TargetType.Dangerous:
                prefab = dangerousPrefab;
                break;
        }

        GameObject targetObject = Object.Instantiate(prefab, position, Quaternion.identity);

        Target target = targetObject.GetComponent<Target>();

        target.Initialize(type);

        return target;
    }
}