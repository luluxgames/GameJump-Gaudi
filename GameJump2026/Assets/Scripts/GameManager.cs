using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }
	public GameObject gameOver;
	public Slider flowerSlider;
	public int flowersTotal = 3;
	public int flowersCollected = 0;

	public CanvasGroup gameOverCanvas;
	public float fadeDuration = 3f;
    private bool showGameOver = false;

    private void Awake()
	{
		flowerSlider.maxValue = flowersTotal;
		Instance = this;


        gameOverCanvas.alpha = 0f;
        gameOver.SetActive(false);

    }

    // Update is called once per frame
    void Update()
	{
		flowerSlider.value = flowersCollected;
		if(flowersCollected==flowersTotal)
		{
			Time.timeScale = 0;
			gameOver.SetActive(true);

            showGameOver = true;
        }


        if (showGameOver)
        {
            gameOverCanvas.alpha = Mathf.MoveTowards(
                gameOverCanvas.alpha, 1f,
                fadeDuration * Time.unscaledDeltaTime
            );
        }

    }
}
