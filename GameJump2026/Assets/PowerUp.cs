using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float respawnTime = 10.0f;

    Collider col;
    MeshRenderer mesh;
    AudioSource aud;

    void Start()
    {
        col = GetComponent<Collider>();
        mesh = GetComponent<MeshRenderer>();
        aud = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider loQueToco)
    {
        if (loQueToco.CompareTag("Player"))
        {
            PlayerMovement player = loQueToco.GetComponent<PlayerMovement>();

            if (player == null)
                player = loQueToco.GetComponentInParent<PlayerMovement>();
            aud.Play();
            player.ActivateSpeedBoost(1.5f, 2.5f);
            StartCoroutine(RespawnRoutine());
        }
    }

    IEnumerator RespawnRoutine()
    {
        col.enabled = false;
        mesh.enabled = false;
        yield return new WaitForSeconds(respawnTime);
        col.enabled = true;
        mesh.enabled = true;
    }
}
