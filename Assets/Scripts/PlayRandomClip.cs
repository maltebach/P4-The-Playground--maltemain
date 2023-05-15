using UnityEngine;

public class PlayRandomClip : MonoBehaviour
{
    public AudioClip[] audioClips;
    private int previousClipIndex = -1;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayRandomAudioClip()
    {
        int randomIndex = Random.Range(0, audioClips.Length);

        // Ensure the same clip is not played twice in a row
        while (randomIndex == previousClipIndex)
        {
            randomIndex = Random.Range(0, audioClips.Length);
        }

        previousClipIndex = randomIndex;

        AudioClip randomClip = audioClips[randomIndex];
        audioSource.PlayOneShot(randomClip);
    }
}
