using UnityEngine;
using UnityEngine.UI;

public class WindowTrigger : MonoBehaviour
{
    public ParticleSystem waterdrops;
    public ParticleSystem pants;
    public Image staminaFiller;
    public PlayerMovement playerMovement;
    bool isInWindow = false;
    bool onceWaterdrops = false;
    bool oncePants = false;
    float staminaTimer = 1.0f;
    float time = 1.0f;

    void Start()
    {
        staminaFiller.fillAmount = staminaTimer;
        staminaFiller.transform.parent.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isInWindow)
        {
            staminaFiller.transform.parent.gameObject.SetActive(true);
            if (!onceWaterdrops)
            {
                waterdrops.Play();
                onceWaterdrops = true;
            }
            time -= Time.deltaTime*0.5f;
            if (time < 0.0f)
            {
                if (!oncePants)
                {
                    pants.Play();
                    oncePants = true;
                }
                time = 0.0f;
                if (playerMovement.flowerOnMouth.activeSelf)
                    playerMovement.LoseRose();
            }
            playerMovement.speed = 5.0f;
        }
        else
        {
            waterdrops.Stop();
            pants.Stop();
            onceWaterdrops = false;
            oncePants = false;
            time += Time.deltaTime;
            if (time > staminaTimer)
            {
                staminaFiller.transform.parent.gameObject.SetActive(false);
                time = staminaTimer;
            }
            playerMovement.speed = 10.0f;
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
