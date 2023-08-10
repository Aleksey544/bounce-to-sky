using UnityEngine;

public class PoolObject : MonoBehaviour
{
    [SerializeField] private int poolCount;
    [SerializeField] private bool autoExpandPool;
    [SerializeField] private Platform platformPrefab;

    private PoolMono<Platform> pool;

    private void Awake()
    {
        pool = new PoolMono<Platform>(platformPrefab, poolCount, transform);
        pool.autoExpand = autoExpandPool;
    }

    public Platform GetPlatform()
    {
        return pool.GetFreeElement();
    }
}
