using UnityEngine;

public class RoseSpawner : MonoBehaviour
{
    int rosesToSpawn = 0;

    void Start()
    {
        rosesToSpawn = GameManager.Instance.flowersTotal;
    }
}
