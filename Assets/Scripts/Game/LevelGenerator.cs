using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    //public GameObject WhiteBlackPlatform;
    //public GameObject BluePlatform;
    //public GameObject GreenPlatform;
    //public GameObject RedYellowPlatform;
    public PoolObject WhiteBlackPlatformsPool;
    public PoolObject BluePlatformsPool;
    public PoolObject GreenPlatformsPool;
    public PoolObject RedYellowPlatformsPool;
    public PoolObject CoinsPool;
    public PoolObject MagnetsPool;
    public PoolObject SputniksPool;
    public CoinItem Coin;
    private LevelElement collectibleItem;
    private LevelElement platform;
    private LevelElement sputnik;
    private PlatformItem platformItem;
    private SputnikItem sputnikItem;
    public int initialPlatformSublevelsCount = 40;
    public float yIncrement = 1.25f;
    public float zIncrement = 2.5f;
    public float yCoinIncrement = 0.7f;
    private int randomPlatform;
    private int randomCollectibleItems;
    private int randomMagnet;
    private bool isGenerateCollectibleItem;
    private float[] platformsXPositions = new float[3];
    public float[] platformsXPositionsRanges = new float[6] { -7f, -4f, -1.5f, 1.5f, 4f, 7f };
    private Vector3 platformPosition;
    private Vector3 collectibleItemPosition;
    private Vector3 sputnikPosition = new Vector3(-7f, 4f, 0f);
    private Quaternion initialCoinRotation;
    private int generatedPlatformLevel = 2;
    private bool isGeneratedSputnik = false;

    // Начальная генерация уровня
    private void Start()
    {
        initialCoinRotation = Coin.transform.rotation;
        GenerateCustomPlatformSublevels(initialPlatformSublevelsCount);
    }

    // Генерация произвольного кол-ва подуровней платформ
    public void GenerateCustomPlatformSublevels(int sublevelsCount)
    {
        for (int i = 0; i < sublevelsCount; i++)
        {
            GenerateOnePlatformSublevels();
        }
    }

    // Основная логика генерации одного подуровня платформ (в одном подуровне предполагается 3 платформы)
	private void GenerateOnePlatformSublevels()
	{
		platformsXPositions[0] = Random.Range(platformsXPositionsRanges[0], platformsXPositionsRanges[1]);
		platformsXPositions[1] = Random.Range(platformsXPositionsRanges[2], platformsXPositionsRanges[3]);
		platformsXPositions[2] = Random.Range(platformsXPositionsRanges[4], platformsXPositionsRanges[5]);

		for (int i = 0; i < 3; i++)
        {
            randomPlatform = Random.Range(1, 11);
            randomCollectibleItems = Random.Range(1, 4);
            PoolObject selectedPool = null;

            switch (randomPlatform)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                    selectedPool = WhiteBlackPlatformsPool;
                    if (randomCollectibleItems == 1)
                        isGenerateCollectibleItem = true;
                    break;
                case 2:
                case 6:
                case 8:
                    selectedPool = BluePlatformsPool;
                    if (randomCollectibleItems == 2)
                        isGenerateCollectibleItem = true;
                    break;
                case 4:
                case 9:
                    selectedPool = GreenPlatformsPool;
                    if (randomCollectibleItems == 3)
                        isGenerateCollectibleItem = true;
                    break;
                case 10:
                    selectedPool = RedYellowPlatformsPool;
                    break;
            }

            platformPosition = new Vector3(platformsXPositions[i],
                generatedPlatformLevel * yIncrement, generatedPlatformLevel * zIncrement);
            platform = InstantiatePoolObject(selectedPool, platformPosition);
            platformItem = platform.GetComponent<PlatformItem>();
            platformItem?.Init();

            if (isGenerateCollectibleItem)
            {
                randomMagnet = Random.Range(1, 8);
                collectibleItemPosition = new Vector3(platformsXPositions[i],
                    generatedPlatformLevel * yIncrement + yCoinIncrement, generatedPlatformLevel * zIncrement);
                // GameObject tempCoin = Instantiate(Coin, coinPosition, initialCoinRotation);

                if (randomMagnet == 1)
                    GenerateCollectibleItems(MagnetsPool);
                else
                    GenerateCollectibleItems(CoinsPool);
            }
        }

        if (generatedPlatformLevel % Random.Range(5, 11) == 0)
        {
            GenerateSputnik();
        }

        generatedPlatformLevel++;
	}

    public void GenerateSputnik()
    {
        sputnikPosition = new Vector3(15f, generatedPlatformLevel * yIncrement + 2.5f,
            generatedPlatformLevel * zIncrement + 1.25f);
        sputnik = InstantiatePoolObject(SputniksPool, sputnikPosition);
        sputnikItem = sputnik.GetComponent<SputnikItem>();
        sputnikItem?.Init();
    }

    // Генерация одной платформы в произвольном месте (для дополнительной жизни)
    public void GenerateOnePlatform(Vector3 platformPosition, int platformsCount)
    {
        Vector3 _platformPosition = platformPosition;

        for (int i = 0; i < platformsCount; i++)
        {
            platform = InstantiatePoolObject(WhiteBlackPlatformsPool, _platformPosition);
            _platformPosition.Set(_platformPosition.x, _platformPosition.y + yIncrement,
                _platformPosition.z + zIncrement);
        }
        
        // for (int i = 0; i < platformsCount; i++)
        //    tempPlatform = InstantiatePoolObject(WhiteBlackPlatformsPool, new Vector3
        //        (platformPosition.x, (platformPosition.y + i) * yIncrement, platformPosition.z + i * zIncrement));
    }

    // Основная логика генерации предметов, которые подбирает игрок
    private void GenerateCollectibleItems(PoolObject itemsPool)
    {
        collectibleItem = InstantiatePoolObject(itemsPool, collectibleItemPosition);
        collectibleItem.transform.localRotation = initialCoinRotation;
        collectibleItem.GetComponent<CollectibleItem>().Init(platformItem.GetPlatformContent());
        isGenerateCollectibleItem = false;
    }

    private LevelElement InstantiatePoolObject(PoolObject selectedPool, Vector3 position)
    {
        LevelElement element = selectedPool.GetLevelElementPrefab();
        element.transform.position = position;
        return element;
    }
}