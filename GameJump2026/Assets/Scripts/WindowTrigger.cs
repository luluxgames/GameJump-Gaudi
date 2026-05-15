using UnityEngine;
using UnityEngine.UI;

public class WindowTrigger : MonoBehaviour
{
    public Image staminaFiller;
    public PlayerMovement playerMovement;
    bool isInWindow = false;
    float staminaTimer = 1.0f;
    float time = 1.0f;

    void Start()
    {
        staminaFiller.fillAmount = staminaTimer;
    }

    void Update()
    {
        if (isInWindow)
        {
            time -= Time.deltaTime;
            if (time < 0.0f)
                time = 0.0f;
            playerMovement.speed = 5.0f;
            playerMovement.acceleration = 10.0f;
        }
        else
        {
            time += Time.deltaTime;
            if (time > staminaTimer)
                time = staminaTimer;
            playerMovement.speed = 10.0f;
            playerMovement.acceleration = 20.0f;
        }
        staminaFiller.fillAmount = time;
    }

    void OnTriggerEnter(Collider other)
    {
        isInWindow = true;
    }

    void OnTriggerExit(Collider other)
    {
        isInWindow = false;
    }
}
