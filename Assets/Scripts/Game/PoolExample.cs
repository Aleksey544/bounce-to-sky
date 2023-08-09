using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolExample : MonoBehaviour
{
    [SerializeField] private int poolCount;
    [SerializeField] private bool autoExpandPool;
    [SerializeField] private Platform platformPrefab;

    private PoolMono<Platform> pool;

    private void Awake()
    {
        this.pool = new PoolMono<Platform>(this.platformPrefab, this.poolCount, this.transform);
        this.pool.autoExpand = this.autoExpandPool;
    }

    //private void Update()
    //{
    //    for (int i = 0; i < 20; i++) 
    //    {
    //        this.CreatePlatform();
    //    }
    //}

    public Platform GetPlatform()
    {
        return pool.GetFreeElement();
    }
}
