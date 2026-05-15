using UnityEngine;

public class RoseTrigger : MonoBehaviour
{
    public bool isFlowerOnPossesion = false;
    PlayerMovement player;

    void Start()
    {
        if (isFlowerOnPossesion)
            player = GetComponentInParent<PlayerMovement>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (isFlowerOnPossesion)
        {
            if (other.CompareTag("Pot"))
            {
                player.flowersOnPosesion--;
                player.flowerOnMouth.SetActive(false);
                PotController pot = other.GetComponent<PotController>();
                pot.AddFlower();
            }
        }
        else
        {
            if (other.CompareTag("Player"))
            {
                player = other.GetComponent<PlayerMovement>();
                if (!player.flowerOnMouth.activeSelf)
                {
                    player.flowersOnPosesion++;
                    player.flowerOnMouth.SetActive(true);
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
