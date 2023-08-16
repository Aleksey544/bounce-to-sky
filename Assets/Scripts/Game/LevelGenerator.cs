using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject WhiteBlackPlatform;
    public GameObject BluePlatform;
    public GameObject GreenPlatform;
    public GameObject RedYellowPlatform;

    public PoolObject WhiteBlackPlatformsPool;
    public PoolObject BluePlatformsPool;
    public PoolObject GreenPlatformsPool;
    public PoolObject RedYellowPlatformsPool;
    public PoolObject CoinsPool;
    public PoolObject MagnetsPool;
  //public CollectibleItemRotator Coin;
    public CoinItem Coin;
    private LevelElement collectibleItem;
    private LevelElement tempPlatform;
    private PlatformItem tempPlatformItem;
    public int initialPlatformSublevelsCount = 40;
    public float yIncrement = 1;
    public float zIncrement = 2;
    public float yCoinIncrement = 0.7f;
    private int randomPlatform;
    private int randomCollectibleItems;
    private int randomMagnet;
    private bool isGenerateCollectibleItem;
    private float[] platformsXPositions = new float[3];
    public float[] platformsXPositionsRanges = new float[6] { -7.0f, -4.0f, -1.5f, 1.5f, 4.0f, 7.0f };
    private Vector3 platformPosition;
    private Vector3 collectibleItemPosition;
    private Quaternion initialCoinRotation;
    private int generatedPlatformLevel = 2;

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
            randomPlatform = Random.Range(1, 8);
            randomCollectibleItems = Random.Range(1, 4);
            PoolObject selectedPool = null;

            switch (randomPlatform)
            {
                case 1:
                case 2:
                case 3:
                    selectedPool = WhiteBlackPlatformsPool;
                    if (randomCollectibleItems == 1)
                        isGenerateCollectibleItem = true;
                    break;
                case 4:
                case 5:
                    selectedPool = BluePlatformsPool;
                    if (randomCollectibleItems == 2)
                        isGenerateCollectibleItem = true;
                    break;
                case 6:
                    selectedPool = GreenPlatformsPool;
                    if (randomCollectibleItems == 3)
                        isGenerateCollectibleItem = true;
                    break;
                case 7:
                    selectedPool = RedYellowPlatformsPool;
                    break;
            }

            platformPosition = new Vector3(platformsXPositions[i], generatedPlatformLevel * yIncrement, generatedPlatformLevel * zIncrement);
            tempPlatform = InstantiatePoolObject(selectedPool, platformPosition);
            tempPlatformItem = tempPlatform.GetComponent<PlatformItem>();
            tempPlatformItem?.Init();

            if (isGenerateCollectibleItem)
            {
                randomMagnet = Random.Range(1, 8);
                collectibleItemPosition = new Vector3(platformsXPositions[i], generatedPlatformLevel * yIncrement + yCoinIncrement, generatedPlatformLevel * zIncrement);
                // GameObject tempCoin = Instantiate(Coin, coinPosition, initialCoinRotation);

                if (randomMagnet == 1)
                    GenerateCollectibleItems(MagnetsPool);
                else
                    GenerateCollectibleItems(CoinsPool);
            }
        }

        generatedPlatformLevel++;
	}

    // Основная логика генерации предметов, которые подбирает игрок
    private void GenerateCollectibleItems(PoolObject itemsPool)
    {
        collectibleItem = InstantiatePoolObject(itemsPool, collectibleItemPosition);
        collectibleItem.transform.localRotation = initialCoinRotation;
        //collectibleItem.transform.position = tempPlatform.transform.position; 
        //collectibleItem.transform.SetParent(tempPlatform.transform);
        collectibleItem.GetComponent<CollectibleItem>().Init(tempPlatformItem.GetPlatformContent());
       
       // tempPlatform.GetComponent<PlatformItem>().AddContentToChild(collectibleItem.transform);

        //CollectibleItemRotator rotatorItem = collectibleItem.GetComponent<CollectibleItemRotator>();

        //if (rotatorItem == null)
        //{
        //    rotatorItem = collectibleItem.gameObject.AddComponent<CollectibleItemRotator>();
        //}

        //Coin coin = item.GetComponent<Coin>().SetMoneyLayer();
        //rotatorItem.SetTarget(tempPlatform.ElementPrefab);
        isGenerateCollectibleItem = false;
    }

    private LevelElement InstantiatePoolObject(PoolObject selectedPool, Vector3 platformPosition)
    {
        LevelElement platform = selectedPool.GetPlatform();
        platform.transform.position = platformPosition;
        return platform;
    }
}