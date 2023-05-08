using UnityEngine;
using System.Collections.Generic;

public class PlayAudioClipsFromList : MonoBehaviour
{
    // The list of audio clips to play
    public List<AudioClip> audioClipList;

    // The audio source component to play the audio clips
    public AudioSource audioSource;

    // Index of the current audio clip being played
    private int currentIndex = 0;


    void Awake()
    {
        if (audioClipList.Count > 0)
        {
            // Get the first audio clip from the list
            AudioClip audioClip = audioClipList[currentIndex];

            // Play the audio clip
            audioSource.clip = audioClip;
            audioSource.Play();

            // Move to the next index in the list, or loop back to the beginning if we've reached the end
            currentIndex = (currentIndex + 1) % audioClipList.Count;
        }
    }

    // Called to play the next audio clip from the list
    public void PlayNextAudioClipFromList()
    {
        if (audioClipList.Count > 0)
        {
            // Get the first audio clip from the list
            AudioClip audioClip = audioClipList[currentIndex];

            // Play the audio clip
            audioSource.clip = audioClip;
            audioSource.Play();

            // Move to the next index in the list, or loop back to the beginning if we've reached the end
            currentIndex = (currentIndex + 1) % audioClipList.Count;
        }
    }
}
