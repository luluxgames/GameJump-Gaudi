using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int flowersTotal = 3;
    public int flowersCollected = 0;

    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(flowersCollected==flowersTotal)
        {
            Debug.Log("GAME OVER!");
        }
    }
}
