using UnityEngine;

public class PoolObject : MonoBehaviour
{
    [SerializeField] private int poolCount;
    [SerializeField] private bool autoExpandPool;
    [SerializeField] private LevelElement platformPrefab;

    private PoolMono<LevelElement> pool;

    private void Awake()
    {
        pool = new PoolMono<LevelElement>(platformPrefab, poolCount, transform);
        pool.autoExpand = autoExpandPool;
    }

    public LevelElement GetPlatform()
    {
        return pool.GetFreeElement();
    }
}
