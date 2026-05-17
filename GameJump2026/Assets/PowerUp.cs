using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float powerupSpeed = 20f;

    private void OnTriggerEnter(Collider loQueToco)
    {
        if (loQueToco.CompareTag("Player"))
        {
            loQueToco.GetComponent<PlayerMovement>().speed = powerupSpeed;

            Destroy(gameObject);
        }
    }
}