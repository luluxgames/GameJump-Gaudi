using UnityEngine;

public class RandomAudioPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    public AudioClip[] audioClips2;
    public bool isGlass = false;

    public void PlayRandomAudio()
    {
        int randomIndex = Random.Range(0, audioClips.Length);
        audioSource.clip = audioClips[randomIndex];
        audioSource.Play();
    }

    public void PlayAudioByRaycast()
    {
        AudioClip[] selectedList;
        if (isGlass)
                selectedList = audioClips2;
        else
            selectedList = audioClips;
        int randomIndex = Random.Range(0, selectedList.Length);
        audioSource.clip = selectedList[randomIndex];
        audioSource.pitch = Random.Range(0.6f, 1.4f);
        audioSource.Play();
    }
}
