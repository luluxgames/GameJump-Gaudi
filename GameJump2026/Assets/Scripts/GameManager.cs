using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Slider flowerSlider;
    public int flowersTotal = 3;
    public int flowersCollected = 0;

    private void Awake()
    {
        flowerSlider.maxValue = flowersTotal;
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        flowerSlider.value = flowersCollected;
        if(flowersCollected==flowersTotal)
        {
            Debug.Log("GAME OVER!");
        }
    }
}
