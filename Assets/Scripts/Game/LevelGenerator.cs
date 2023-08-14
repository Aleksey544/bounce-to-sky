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
    public GameObject Coin;
    private Platform reward;
	public int initialPlatformCount = 15;
	public float yIncrement = 1;
	public float zIncrement = 2;
	public float yCoinIncrement = 0.7f;
	private int randomPlatform;
	private int randomCoin;
    private int randomMagnet;
	private bool isGenerateCoin;
	private float[] platformsXPositions = new float[3];
	public float[] platformsXPositionsRanges = new float[6] {-7.0f, -4.0f, -1.5f, 1.5f, 4.0f, 7.0f};
	private Vector3 platformPosition;
	private Vector3 coinPosition;
	private Quaternion initialCoinRotation;
	private int generatedPlatformLevel = 2;

	private void Start()
	{
		initialCoinRotation = Coin.transform.rotation;
		GeneratePlatforms(initialPlatformCount);
	}

	public void GeneratePlatforms(int platformsCount)
	{
		for (int i = 0; i < platformsCount; i++)
		{
			GeneratePlatform();
		}
	}

	private void GeneratePlatform()
	{
		platformsXPositions[0] = Random.Range(platformsXPositionsRanges[0], platformsXPositionsRanges[1]);
		platformsXPositions[1] = Random.Range(platformsXPositionsRanges[2], platformsXPositionsRanges[3]);
		platformsXPositions[2] = Random.Range(platformsXPositionsRanges[4], platformsXPositionsRanges[5]);

		for (int i = 0; i < 3; i++)
        {
            randomPlatform = Random.Range(1, 8);
            randomCoin = Random.Range(1, 4);
            PoolObject selectedPool = null;

            switch (randomPlatform)
            {
                case 1:
                case 2:
                case 3:
                    selectedPool = WhiteBlackPlatformsPool;
                    if (randomCoin == 1)
                        isGenerateCoin = true;
                    break;
                case 4:
                case 5:
                    selectedPool = BluePlatformsPool;
                    if (randomCoin == 2)
                        isGenerateCoin = true;
                    break;
                case 6:
                    selectedPool = GreenPlatformsPool;
                    if (randomCoin == 3)
                        isGenerateCoin = true;
                    break;
                case 7:
                    selectedPool = RedYellowPlatformsPool;
                    break;
            }

            platformPosition = new Vector3(platformsXPositions[i], generatedPlatformLevel * yIncrement, generatedPlatformLevel * zIncrement);
            Platform tempPlatform = InstantiatePoolObject(selectedPool, platformPosition);

            if (isGenerateCoin)
            {
                randomMagnet = Random.Range(1, 8);
                coinPosition = new Vector3(platformsXPositions[i], generatedPlatformLevel * yIncrement + yCoinIncrement, generatedPlatformLevel * zIncrement);
             // GameObject tempCoin = Instantiate(Coin, coinPosition, initialCoinRotation);
                if (randomMagnet == 1)
                    reward = InstantiatePoolObject(MagnetsPool, coinPosition);
                else
                    reward = InstantiatePoolObject(CoinsPool, coinPosition);

                reward.transform.localRotation = initialCoinRotation;
                reward.transform.SetParent(tempPlatform.transform);
                CoinMovement coin = reward.GetComponent<CoinMovement>();
                if (coin == null) 
                {
                    coin = reward.gameObject.AddComponent<CoinMovement>();
                }
                coin.SetMoneyLayer();
                coin.SetTarget(tempPlatform.PlatformModel);
                isGenerateCoin = false;
            }
        }

        generatedPlatformLevel++;
	}

    private Platform InstantiatePoolObject(PoolObject selectedPool, Vector3 platformPosition)
    {
        Platform platform = selectedPool.GetPlatform();
        platform.transform.position = platformPosition;
        return platform;
    }
}