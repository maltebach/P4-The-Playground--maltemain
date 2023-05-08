using UnityEngine;
using System.Collections.Generic;

public class AudioQueuer : MonoBehaviour
{
    // A list of audio clips to play
    public List<AudioClip> audioClips;

    // The AudioSource component to play the audio clips
    public AudioSource audioSource;

    // The index of the current audio clip to play
    private int currentClipIndex = 0;

    // Called when the object is first created
    void Start()
    {
        // Set the audio source to loop
        audioSource.loop = false;

        // Start playing the first audio clip in the list
        PlayNextClip();
    }

    // Called every frame
    void Update()
    {
        // If the current audio clip has finished playing
        if (!audioSource.isPlaying)
        {
            // Play the next audio clip in the list
            PlayNextClip();
        }
    }

    // Plays the next audio clip in the list
    private void PlayNextClip()
    {
        // If there are more audio clips to play
        if (currentClipIndex < audioClips.Count)
        {
            // Set the audio source's clip to the next clip in the list
            audioSource.clip = audioClips[currentClipIndex];

            // Play the audio clip
            audioSource.Play();

            // Increment the current clip index
            currentClipIndex++;
        }
        // If there are no more audio clips to play
        else
        {
            // Reset the current clip index to 0 to play the first clip again
            audioSource.Stop();
        }
    }
}
