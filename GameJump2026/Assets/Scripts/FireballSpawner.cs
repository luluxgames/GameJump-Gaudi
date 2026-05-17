using UnityEngine;

public class FireballSpawner : MonoBehaviour
{
    public GameObject fireballPrefab;
    public GameObject fireballsPrefab;
    public Transform spawnPoint;

    float spawnPercentage = 0.75f;

    public void SpawnFireball()
    {
        float percentage = (float)GameManager.Instance.flowersCollected / GameManager.Instance.flowersTotal;
        if (percentage >= spawnPercentage)
            Instantiate(fireballsPrefab, spawnPoint.position, spawnPoint.rotation);
        else
            Instantiate(fireballPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
