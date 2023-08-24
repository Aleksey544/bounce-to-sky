using UnityEngine;

public class PoolObject : MonoBehaviour
{
    [SerializeField] private int poolCount;
    [SerializeField] private bool autoExpandPool;
    [SerializeField] private LevelElement levelElementPrefab;

    private PoolMono<LevelElement> pool;

    private void Awake()
    {
        pool = new PoolMono<LevelElement>(levelElementPrefab, poolCount, transform);
        pool.autoExpand = autoExpandPool;
    }

    public LevelElement GetLevelElementPrefab()
    {
        return pool.GetFreeElement();
    }
}
