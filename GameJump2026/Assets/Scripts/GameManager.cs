using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }
	public GameObject gameOver;
	public TextMeshProUGUI flowerText;

    public GameObject normas;

	public int flowersTotal = 3;
	public int flowersCollected = 0;

	public CanvasGroup gameOverCanvas;
	public float fadeDuration = 3f;
    private bool showGameOver = false;

    private void Awake()
	{
        flowerText.text = flowersTotal.ToString();
		Instance = this;


        gameOverCanvas.alpha = 0f;
        gameOver.SetActive(false);

    }

    private void Start()
    {
        Time.timeScale = 0f;
        normas.SetActive(true);
    }

    public void ExitNormas()
    {
        Time.timeScale = 1f;
        normas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
	{
        flowerText.text = (flowersCollected + "/" + flowersTotal).ToString();
        if (flowersCollected==flowersTotal)
		{
			Time.timeScale = 0;
			gameOver.SetActive(true);

            showGameOver = true;
        }
        if (showGameOver)
            gameOverCanvas.alpha = Mathf.MoveTowards(gameOverCanvas.alpha, 1f, fadeDuration * Time.unscaledDeltaTime);
    }
}
