using UnityEngine;

public class FireballSpawner : MonoBehaviour
{
    public GameObject fireballPrefab;
    public Transform spawnPoint;

    public void SpawnFireball()
    {
        Instantiate(fireballPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
