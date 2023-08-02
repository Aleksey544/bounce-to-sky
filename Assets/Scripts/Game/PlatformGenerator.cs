//Скрипт генерации платформ
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
	public GameObject WhiteBlackPlatform;
	public GameObject BluePlatform;
	public GameObject GreenPlatform;
	public GameObject RedYellowPlatform;
	private GameObject platformType;
	public GameObject Coin;
	public int initialPlatformCount = 15;
	public float yIncrement = 1;
	public float zIncrement = 2;
	public float yCoinIncrement = 0.7f;
	private int randomPlatform;
	private int randomCoin;
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
			randomCoin = Random.Range(1, 10);
			
			switch (randomPlatform)
			{
				case 1: case 2: case 3:
					platformType = WhiteBlackPlatform;
					if (randomCoin == 1)
						isGenerateCoin = true;
					break;
				case 4: case 5:
					platformType = BluePlatform;
					if (randomCoin == 3)
						isGenerateCoin = true;
					break;
				case 6:
					platformType = GreenPlatform;
					if (randomCoin == 6)
						isGenerateCoin = true;
					break;
				case 7:
					platformType = RedYellowPlatform;
					break;
			}

			platformPosition = new Vector3(platformsXPositions[i], generatedPlatformLevel * yIncrement, generatedPlatformLevel * zIncrement);
			GameObject tempPlatform = Instantiate(platformType, platformPosition, Quaternion.identity);

			if (isGenerateCoin)
			{
				coinPosition = new Vector3(platformsXPositions[i], generatedPlatformLevel * yIncrement + yCoinIncrement, generatedPlatformLevel * zIncrement);
				GameObject tempCoin = Instantiate(Coin, coinPosition, initialCoinRotation);
				tempCoin.transform.SetParent(tempPlatform.transform);
				isGenerateCoin = false;
			}
		}

		generatedPlatformLevel++;
	}
}