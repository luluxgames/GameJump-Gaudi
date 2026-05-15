using UnityEngine;

public class TriggerFX : MonoBehaviour
{
    ParticleSystem _particleSystem;

    void OnTriggerEnter(Collider other)
    {
        _particleSystem.Play();
    }
}
