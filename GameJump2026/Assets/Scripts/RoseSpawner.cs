using UnityEngine;

public class RoseSpawner : MonoBehaviour
{
	public GameObject rosePrefab;
	public int rosesToSpawn = 12;
	public float spawnWidth = 10f;

	void Start()
	{
		rosesToSpawn = GameManager.Instance.flowersTotal;
		SpawnRoses();
	}

	void SpawnRoses()
	{
		float startX = transform.position.x - (spawnWidth / 2f);
		float spacing = spawnWidth / (rosesToSpawn - 1);

		for (int i = 0; i < rosesToSpawn; i++)
		{
			Vector3 spawnPos = new Vector3(startX + (spacing * i), transform.position.y, transform.position.z);
			Instantiate(rosePrefab, spawnPos, Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));
		}
	}
}
