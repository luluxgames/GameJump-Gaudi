using UnityEngine;

public class RoseTrigger : MonoBehaviour
{
    public bool isFlowerOnPossesion = false;

    void OnTriggerEnter(Collider other)
    {
        if (isFlowerOnPossesion)
        {
            if (other.CompareTag("Pot"))
            {

            }
        }
        else
        {
            if (other.CompareTag("Player"))
            {
                PlayerMovement player = other.GetComponent<PlayerMovement>();
                player.flowersOnPosesion++;
                player.flowerOnMouth.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }
}
